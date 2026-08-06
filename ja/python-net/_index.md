---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /ja/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python 用 PowerPoint 自動化
- Python PPT ライブラリ
- Python で PowerPoint を PDF にエクスポート
- Python で PowerPoint を SVG にエクスポート
- Python で PowerPoint を編集
- Microsoft Office 不要の Python PowerPoint
- Python で PPTX を管理
- Python のスライドプレビュー
- Python でスライドにオーディオを追加
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET は、テキスト、シェイプ、テーブル、アニメーションの管理、スライドへのオーディオおよびビデオの追加、スライドのプレビュー、SVG、PDF などへのエクスポートを含む包括的な機能セットを提供します。"
---
{{% alert color="primary" %}}

**Aspose.Slides for Python via .NET へようこそ**

![Aspose.Slides for Python via .NET 製品ロゴ](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET は、Microsoft PowerPoint® を必要とせずに、アプリケーションが PowerPoint® プレゼンテーションを読み書きできる堅牢なクラス ライブラリです。

Python 開発者向けに、完全機能の PowerPoint® ドキュメント管理を提供する初めてで唯一のコンポーネントです。

Aspose.Slides for Python via .NET には、テキスト、シェイプ、テーブル、アニメーションの操作、オーディオやビデオの追加、スライドのプレビュー、SVG、PDF などへのエクスポートなど、幅広い機能が含まれています。

{{% /alert %}}

## Aspose.Slides for Python via .NET のインストール

```bash
pip install aspose.slides
```

パッケージには必要な .NET ランタイムが同梱されているため、追加でインストールするものはなく、Microsoft PowerPoint も必要ありません。Windows、Linux、macOS 上の Python 3.7 以降に対応しています。

## Python で PowerPoint プレゼンテーションを作成する

この例ではプレゼンテーションを作成し、1枚目のスライドにテキスト付きのシェイプを追加し、結果を PPTX と PDF の両方で保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

実行すると、作業ディレクトリに `presentation.pptx`（約 34 KB）と `presentation.pdf`（約 36 KB）が作成されます。

ライセンスがない場合、ライブラリは評価モードで動作し、透かしが付加されスライド数が制限されます。ライセンスを適用するには、[Licensing](/slides/ja/python-net/licensing/) を参照してください。

## Aspose.Slides for Python via .NET のリソース

以下の便利なリソースをご覧ください：

- [Aspose.Slides for Python via .NET オンラインドキュメント](/slides/ja/python-net/)
- [Aspose.Slides for Python via .NET 機能](/slides/ja/python-net/features-overview/)
- [Aspose.Slides for Python via .NET リリースノート](https://releases.aspose.com/slides/ja/python-net/release-notes/)
- [Aspose.Slides for Python via .NET 製品ページ](https://products.aspose.com/slides/ja/python-net/)
- [Aspose.Slides for Python via .NET のダウンロード](https://releases.aspose.com/slides/ja/python-net/)
- [Aspose.Slides for Python via .NET PyPi パッケージのインストール](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API リファレンス ガイド](https://reference.aspose.com/slides/ja/python-net/)
- [Aspose.Slides for Python via .NET 無料サポート フォーラム](https://forum.aspose.com/c/slides/ja/11)
- [Aspose.Slides for Python via .NET 有料サポート ヘルプデスク](https://helpdesk.aspose.com/)

## FAQ

### Aspose.Slides for Python via .NET とは何ですか？

Aspose.Slides for Python via .NET は、Microsoft PowerPoint をインストールせずに、プログラムから PowerPoint プレゼンテーション（PPT、PPTX、ODP）を作成、編集、変換できる強力な Python ライブラリです。

### Aspose.Slides はどのようなプレゼンテーション機能をサポートしていますか？

ライブラリは、テキスト、シェイプ、テーブル、チャート、アニメーション、マスタースライド、オーディオ、ビデオなどの管理をサポートします。また、スライドのプレビュー、レンダリング、印刷、PDF、SVG、HTML、画像などへのエクスポートも可能です。

### Aspose.Slides を使用してプレゼンテーションを他の形式に変換できますか？

はい。Aspose.Slides を使用すると、PowerPoint ファイルを PDF、SVG、HTML、JPG、PNG、TIFF などの形式に高忠実度かつ高速に変換できます。

### Aspose.Slides の使用に Microsoft PowerPoint は必要ですか？

いいえ。Aspose.Slides はスタンドアロン API であり、Microsoft Office やサードパーティ ソフトウェアは必要ありません。

### Aspose.Slides for Python via .NET はどのプラットフォームをサポートしていますか？

Windows、Linux、macOS の各環境で動作するクロスプラットフォームです。

### Aspose.Slides for Python の入門方法は？

PyPi からインストールし、[開発者ガイド](/slides/ja/python-net/developer-guide/) を参照して、サンプル、API リファレンス、チュートリアルを確認してください。