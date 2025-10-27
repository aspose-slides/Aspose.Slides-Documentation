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
description: "Aspose.Slides for Python via .NET のシステム要件を確認してください。Windows、Linux、macOS で PowerPoint および OpenDocument のシームレスなサポートを実現します。"
---

## **はじめに**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint などのサードパーティ製品をインストールする必要はありません。Aspose.Slides は、Microsoft PowerPoint プレゼンテーション形式を含むさまざまな形式のドキュメントを作成、変更、変換、レンダリングするエンジンです。

## **対応オペレーティングシステム**

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

## **対象LinuxおよびmacOSプラットフォームのシステム要件**

- GCC 6 ランタイムライブラリ（またはそれ以降）。
- [libgdiplus](https://github.com/mono/libgdiplus)、GDI+ API のオープンソース実装です。
- .NET Core Runtime の依存関係です。.NET Core Runtime 自体のインストールは不要です。
- Python 3.5–3.7 の場合、`pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルドオプションはデフォルトで有効になっています。通常、`pymalloc` ビルドの Python はファイル名に `m` サフィックスが付いています。
- `libpython` 共有ライブラリ。`--enable-shared` Python ビルドオプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux の一部プラットフォームでは、パッケージマネージャ（例: `sudo apt-get install libpython3.7`）で `libpython` 共有ライブラリをインストールできます。一般的な問題は、`libpython` ライブラリが共有ライブラリ用の標準以外の場所にインストールされていることです。Python をコンパイルするときにビルドオプションで代替ライブラリパスを設定するか、システムの標準共有ライブラリディレクトリに `libpython` ライブラリへのシンボリックリンクを作成することで解決できます。通常、Python 3.5–3.7 の場合は `libpythonX.Ym.so.1.0`、Python 3.8 以降は `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）というファイル名です。

## **FAQ**

**変換やレンダリングに Microsoft PowerPoint のインストールは必要ですか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は、[作成](/slides/ja/python-net/create-presentation/)、変更、[変換](/slides/ja/python-net/convert-presentation/)、および [レンダリング](/slides/ja/python-net/convert-powerpoint-to-png/) を行うためのスタンドアロンエンジンです。

**マシンに特定の .NET バージョン（Core/5+/6+）は必要ですか？**

.NET Runtime 自体のインストールは不要ですが、Linux/macOS ではその依存関係が存在する必要があります。つまり、Runtime をフルインストールせずに、通常 .NET の依存パッケージとしてインストールされるものをシステムに含めておく必要があります。

**正しいレンダリングのために必要なフォントは何ですか？**

プレゼンテーションで使用されているフォント、または適切な[代替フォント](/slides/ja/python-net/font-substitution/) が利用可能である必要があります。Linux/macOS での一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることをお勧めします。