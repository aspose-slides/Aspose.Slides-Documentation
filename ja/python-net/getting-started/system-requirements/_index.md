---
title: システム要件
type: docs
weight: 60
url: /ja/python-net/system-requirements/
keywords:
- システム要件
- オペレーティングシステム
- インストール
- 依存関係
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のシステム要件を確認してください。Windows、Linux、macOS での PowerPoint と OpenDocument のシームレスなサポートを実現します。"
---
## **はじめに**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint などのサードパーティ製品をインストールする必要がありません。Aspose.Slides は、Microsoft PowerPoint プレゼンテーション形式を含むさまざまなフォーマットのドキュメントを作成、変更、変換、レンダリングするエンジンです。

## **サポートされているオペレーティングシステム**

Aspose.Slides for Python は、Windows（32 ビットおよび 64 ビット）、macOS、Python 3.5 以降がインストールされたシステム上の 64 ビット Linux をサポートします。

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">オペレーティングシステム</td>
        <td style="font-weight: bold; width:400px">バージョン</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>その他</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Linux および macOS プラットフォーム向けのシステム要件**

- GCC 6 ランタイムライブラリ（またはそれ以降）。
- [libgdiplus](https://github.com/mono/libgdiplus) は、GDI+ API のオープンソース実装です。
- .NET Core Runtime の依存関係です。.NET Core Runtime 自体のインストールは不要です。
- Python 3.5–3.7 の場合: Python の `pymalloc` ビルドが必要です。`--with-pymalloc` ビルドオプションはデフォルトで有効になっています。通常、`pymalloc` ビルドの Python はファイル名に `m` サフィックスが付けられています。
- `libpython` 共有ライブラリ。`--enable-shared` Python ビルドオプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux の一部プラットフォームでは、パッケージマネージャー（例: `sudo apt-get install libpython3.7`）を使用して `libpython` 共有ライブラリをインストールできます。一般的な問題として、`libpython` ライブラリが共有ライブラリ用の標準外の場所にインストールされていることがあります。Python をコンパイルするときにビルドオプションで代替ライブラリパスを設定するか、システムの標準共有ライブラリ場所に `libpython` ライブラリへのシンボリックリンクを作成することで解決できます。通常、`libpython` 共有ライブラリのファイル名は Python 3.5–3.7 では `libpythonX.Ym.so.1.0`、Python 3.8 以降では `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

## **FAQ**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は、プレゼンテーションを[作成](/slides/ja/python-net/create-presentation/)、変更、[変換](/slides/ja/python-net/convert-presentation/)、および[レンダリング](/slides/ja/python-net/convert-powerpoint-to-png/)するためのスタンドアロンエンジンです。

**マシンに特定の .NET バージョン（Core/5+/6+）が必要ですか？**

.NET Runtime 自体のインストールは不要ですが、その依存関係は Linux/macOS に存在する必要があります。つまり、ランタイム全体をインストールせずに、通常 .NET の依存関係としてインストールされるパッケージをシステムに含める必要があります。

**正しいレンダリングのために必要なフォントはどれですか？**

実際には、プレゼンテーションで使用されているフォント、または適切な[代替フォント](/slides/ja/python-net/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることが推奨されます。

**Linux でカスタムフォントがフォールバックや欠落テキストとしてレンダリングされるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損している場合、Linux のフォントマッチングスタック（FreeType/fontconfig）は無効なレコードを選択し、フォントが解決できない状態になります。 name テーブルレコードが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすることで問題は解決します。