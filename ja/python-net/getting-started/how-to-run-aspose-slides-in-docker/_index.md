---
title: Docker で Aspose.Slides を実行する方法
linktitle: Docker の Aspose.Slides
type: docs
weight: 150
url: /ja/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker の Aspose.Slides
- Docker コンテナ
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Docker で .NET 経由の Python 用 Aspose.Slides を実行する方法：動作する Dockerfile、パッケージが必要とするネイティブ ライブラリ、フォント設定、およびコンテナ内のライセンス管理"
---
## **概要**

Aspose.Slides for Python via .NET は Linux コンテナで実行されますが、パッケージはバンドルされた .NET Core 3.1 ランタイムをラップする Python ラッパーです。そのランタイムは、スリム版 Python イメージには含まれていない 3 つのネイティブ ライブラリを必要とし、バージョンにも厳格です。本記事では動作する Dockerfile を示し、各依存関係の理由を説明し、フォントとライセンスの追加方法を紹介します。

## **動作する Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

ビルドと実行:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **ベースイメージが Debian 11 である理由**

`aspose.slides` の wheel には **.NET Core 3.1** ランタイムがバンドルされており、このランタイムは現在の Debian リリースが提供するライブラリのバージョンよりも古いものです。Debian 12 と 13 ではコンテナは正常にビルドされますが、最初の `Presentation()` 呼び出しで失敗します。

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

メッセージは誤解を招きます――ICU はこれらのイメージにインストールされていますが、バージョンは 72 または 76 で、.NET Core 3.1 は古いメジャー バージョンしか認識しません。Debian 12 ではさらに OpenSSL 3 が搭載されており、二つ目のエラーが発生します。

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` は Debian 11 であり、バンドルされたランタイムが期待する両方のバージョンが揃っています。

| パッケージ | Debian 11 のバージョン | 必要な理由 |
|---|---|---|
| `libgdiplus` | 6.0.4 | 図形、テキスト、画像の描画に使用される GDI+ 実装 |
| `libicu67` | 67.1 | グローバリゼーション データ。新しいメジャーは .NET Core 3.1 で認識されない |
| `libssl1.1` | 1.1.1w | 暗号化。Debian 11 にプリインストールされているが、Debian 12 以降にはない |
| `libfontconfig1` | — | フォント検出 |

`libssl1.1` はベースイメージに既に含まれているため、`apt-get install` に列挙する必要はありません。

どうしても新しいベースイメージを使用する場合は、`DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` を設定して ICU の要件を回避できます。この設定はカルチャ固有の書式設定を無効にしますが、OpenSSL の問題は解決しないため、依然として Debian 11 がシンプルな選択肢です。

## **フォント**

スリムイメージにはフォントが一切含まれていません。最低でも1つのフォントがインストールされていないと、PDF、画像、HTML の出力でテキストが空白のボックスとして表示されます。`fonts-dejavu-core` は小規模で汎用的な開始点です。

プレゼンテーションの意図した外観に合わせるには、使用するフォントをイメージにコピーし、Aspose.Slides にそれらを指示します。

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **コンテナ内でのライセンス管理**

ライセンス ファイルをイメージに組み込まないでください――イメージを取得した誰でもライセンスが取得できます。実行時にマウントしてください。

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

ライセンスがない場合、ライブラリは評価モードで動作し、透かしが付加され、処理できるスライド数が制限されます。詳細は[ライセンス](/slides/ja/python-net/licensing/)をご覧ください。

## **メモリ**

PDF や画像へのレンダリングはファイル読み込みよりもメモリを多く消費します。メモリ制限の厳しいコンテナは変換途中で OOM キラーによりプロセスが終了し、Python のトレースバックが表示されないことがあります。その場合はコードを調査する前にコンテナのメモリ上限を引き上げてください。