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
description: "Aspose.Slides for Python via .NET のシステム要件を確認してください。Windows、Linux、macOS で PowerPoint と OpenDocument のシームレスなサポートを実現します。"
---

## **はじめに**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint などのサードパーティ製品をインストールする必要がありません。Aspose.Slides は、Microsoft PowerPoint プレゼンテーション形式を含むさまざまな形式のドキュメントを作成、変更、変換、レンダリングするエンジンです。

## **サポートされているオペレーティングシステム**

Aspose.Slides for Python は、Windows（32 ビットおよび 64 ビット）、macOS、Python 3.5 以降がインストールされた 64 ビット Linux をサポートします。

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

## **Linux および macOS プラットフォーム向けシステム要件**

- GCC 6 ランタイムライブラリ（以降バージョン）  
- [libgdiplus](https://github.com/mono/libgdiplus)、GDI+ API のオープンソース実装です。  
- .NET Core Runtime の依存関係。 .NET Core Runtime 自体をインストールする必要は **ありません**。  
- Python 3.5–3.7 用: `pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルドオプションはデフォルトで有効になっています。通常、`pymalloc` ビルドの Python はファイル名に `m` サフィックスが付いています。  
- `libpython` 共有ライブラリ。`--enable-shared` Python ビルドオプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux の場合、パッケージマネージャーで `libpython` をインストールできます（例: `sudo apt-get install libpython3.7`）。`libpython` ライブラリが非標準の場所にインストールされていることが一般的な問題です。Python のビルドオプションで代替ライブラリパスを指定するか、システム標準の共有ライブラリディレクトリにシンボリックリンクを作成することで対処できます。通常、`libpython` 共有ライブラリのファイル名は Python 3.5–3.7 では `libpythonX.Ym.so.1.0`、Python 3.8 以降では `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

## **よくある質問**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は不要です。Aspose.Slides は、プレゼンテーションの[作成](/slides/ja/python-net/create-presentation/)、変更、[変換](/slides/ja/python-net/convert-presentation/)、および[レンダリング](/slides/ja/python-net/convert-powerpoint-to-png/)を行うスタンドアロンエンジンです。

**マシンに特定の .NET バージョン（Core/5+/6+）が必要ですか？**

.NET Runtime 自体をインストールする必要はありませんが、その依存関係は Linux/macOS に存在する必要があります。つまり、ランタイム全体をインストールせずに、.NET の依存パッケージがシステムに含まれていることが求められます。

**正しいレンダリングのためにどのフォントが必要ですか？**

プレゼンテーションで使用されているフォント、または適切な[代替フォント](/slides/ja/python-net/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを実現するために、一般的なフォントパッケージのインストールを推奨します。