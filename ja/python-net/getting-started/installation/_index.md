---
title: インストール
type: docs
weight: 70
url: /ja/python-net/installation/
keywords:
- Aspose.Slides をダウンロード
- Aspose.Slides をインストール
- Aspose.Slides を使用
- Aspose.Slides のインストール
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Windows、Linux、macOS 上で、PyPI から pip を使用して .NET 経由の Aspose.Slides for Python をインストールし、Linux と macOS が必要とするネイティブライブラリもインストールします。"
---
## **概要**

この記事では、Windows、Linux、macOS 上で .NET 経由で Python 用 Aspose.Slides をインストールする方法を説明します。パッケージは[PyPI](https://pypi.org/project/aspose.slides/)に公開されており、pip でインストールします。.NET ランタイムが同梱されているため、別途 .NET をインストールする必要はありません。Linux と macOS では、ランタイムが OS に含まれていない可能性のあるネイティブライブラリを必要とします。以下のセクションでそれらを示します。

Aspose.Slides for Python via .NET は Python 3.5 から 3.14 をサポートしています。PyPI では Windows（32 ビットおよび 64 ビット）、Linux（x86_64 および ARM64）、macOS（Intel と Apple silicon）向けのパッケージが提供されています。

## **Windows**

Windows では、pip でパッケージをインストールします。他のライブラリは必要ありません。

```bash
pip install aspose.slides
```

## **Linux**

Linux では、パッケージに含まれる .NET ランタイムが次の 2 つのライブラリを必要とします：

- **libgdiplus** は Windows の GDI+ グラフィック API の実装です。これが無いと、プレゼンテーションの保存時にエラー `The type initializer for 'Gdip' threw an exception` が発生します。
- **ICU**（International Components for Unicode）。これが無いと、最初の Aspose.Slides 呼び出し時に Python プロセスが終了し、`Couldn't find a valid ICU package installed on the system` というメッセージが表示されます。

Debian および Ubuntu では、apt を使って両方をインストールします：

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU パッケージの名前にはバージョンが含まれます。`libicu76` は Debian 13 用のパッケージです。Debian 12 では代わりに `libicu72`、Ubuntu 24.04 では `libicu74` をインストールしてください。システム上で名前を確認するには、次のコマンドを実行します：

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

その後、仮想環境にパッケージをインストールします。現在の Debian および Ubuntu のリリースでは、システム Python は仮想環境外での `pip install` を許可せず、`externally-managed-environment` エラーで停止します。

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

スクリプトは、同じ仮想環境をアクティブにした状態で実行してください。ディストリビューションが管理しない Python（例: 公式 `python` Docker イメージ内のもの）を使用する場合は、仮想環境なしでも `pip install aspose.slides` を実行できます。

プレゼンテーションで使用するフォント、または適切な代替フォントは、スライドを PDF や画像に変換する際にテキストが正しく表示されるようシステムにインストールしておく必要があります。

## **macOS**

macOS でのインストールはまだ検証していません。macOS では、Aspose.Slides が以下の前提条件を必要とします：

- **共有ライブラリ付き Python**、すなわち `--enable-shared` オプションでビルドされた Python です。[pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) で Python をインストールする場合、Python バージョンをインストールするときに環境変数 `PYTHON_CONFIGURE_OPTS` を `--enable-shared` に設定してください。
- **システムライブラリディレクトリにある libpython ライブラリ**。pyenv でインストールした Python は *~/.pyenv/versions* 配下に *libpython3.9.dylib* などの libpython ライブラリを保持します。これへのシンボリックリンクを */usr/local/lib* に作成してください。
- **libgdiplus** は Windows の GDI+ グラフィック API の実装です。Homebrew では `mono-libgdiplus` パッケージとして提供されています。

その後、pip でパッケージをインストールします。

## **インストールの確認**

インストールを確認するには、[Create Presentations](/slides/ja/python-net/create-presentation/) の最初の例を *hello.py* として保存し、`python hello.py` を実行します。現在のフォルダーに *new_presentation.pptx* が保存されます。

## **アップグレード**

既存のインストールを最新バージョンにアップグレードするには、パッケージをインストールした環境で次のコマンドを実行してください：

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**仮想環境に Aspose.Slides をインストールできますか？**

はい。pip を使用して任意の Python 仮想環境にインストールできます。Linux と macOS が必要とするネイティブライブラリはシステムにインストールされ、仮想環境内にはインストールされません。

**Docker コンテナで Aspose.Slides を使用できますか？**

はい。イメージには Linux システムと同様のネイティブライブラリ（libgdiplus と ICU）およびプレゼンテーションで使用するフォントを含める必要があります。

**無料版や評価版の制限はありますか？**

はい。ライセンスがない場合、Aspose.Slides は評価モードで動作し、保存するすべてのスライドに評価用の透かしが付与され、プレゼンテーションから読み取ったテキストが切り詰められます。これらの制限を解除するには、有効な[license](/slides/ja/python-net/licensing/) を適用してください。