---
title: システム要件
type: docs
weight: 60
url: /ja/python-net/system-requirements/
---
Aspose.Slides for Python via .NETは、Microsoft PowerPointなどのサードパーティ製品をインストールする必要はありません。Aspose.Slides自体は、Microsoft PowerPointプレゼンテーション形式を含むさまざまな形式のドキュメントを作成、変更、変換、レンダリングするためのエンジンです。

## 対応オペレーティングシステム

Aspose.Slides for Python via .NETは、Python 3.5以降がインストールされているWindows 64ビットおよび32ビット、macOS、Linux 64ビットオペレーティングシステムをサポートしています。

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

## ターゲットLinuxおよびmacOSプラットフォームのシステム要件

- GCC-6ランタイムライブラリ（またはそれ以降）。
- [`libgdiplus`](https://github.com/mono/libgdiplus): GDI+ APIのオープンソース実装。
- .NET Core Runtimeの依存関係。 .NET Core Runtime自体をインストールする必要はありません。
- Python 3.5-3.7の場合: `pymalloc`ビルドのPythonが必要です。 `--with-pymalloc` Pythonビルドオプションはデフォルトで有効になっています。通常、`pymalloc`ビルドのPythonは、ファイル名に`m`サフィックスが付けられています。
- `libpython`共有Pythonライブラリ。 `--enable-shared` Pythonビルドオプションはデフォルトで無効になっています。一部のPythonディストリビューションには`libpython`共有ライブラリが含まれていません。一部のLinuxプラットフォームでは、パッケージマネージャを使用して`libpython`共有ライブラリをインストールできます。例えば: `sudo apt-get install libpython3.7`。一般的な問題は、`libpython`ライブラリが共有ライブラリの標準システムロケーションとは異なる場所にインストールされることです。この問題は、Pythonをコンパイルする際に代替ライブラリパスを設定するためのPythonビルドオプションを使用することで解決できます。または、システムの共有ライブラリの標準ロケーションに`libpython`ライブラリファイルへのシンボリックリンクを作成することで解決できます。通常、`libpython`共有ライブラリファイル名は、Python 3.5-3.7の場合は`libpythonX.Ym.so.1.0`、Python 3.8以降の場合は`libpythonX.Y.so.1.0`です（例えば: libpython3.7m.so.1.0、libpython3.9.so.1.0）。