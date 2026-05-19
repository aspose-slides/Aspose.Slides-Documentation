---
title: システム要件
type: docs
weight: 80
url: /ja/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のシステム要件を確認してください。Windows、Linux、macOS で PowerPoint と OpenDocument のシームレスなサポートを確保します。"
---
## **はじめに**

Aspose.Slides は Microsoft PowerPoint をインストールする必要がありません。Aspose.Slides は独立した Microsoft PowerPoint ドキュメント作成、変換、ページレイアウト、レンダリングエンジンです。

## **サポートされているオペレーティングシステム**
Aspose.Slides for C++ はネイティブ C++ ライブラリです。Aspose.Slides for C++ は以下の 64 ビットおよび 32 ビットのオペレーティングシステムとプラットフォームをサポートします。

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04以降。
- CentOS 8以降。
- Fedora 24以降。
- その他のglibc 2.23以降を搭載したLinux x86_64。

### **macOS**
- macOS Monterey 12.1以降。

## **開発環境**
Windows、Linux、macOS 向けアプリケーションの開発時に Aspose.Slides for C++ を使用できます。

### **Windows**
- Microsoft Visual Studio 2017以降。
- CMake 3.18以降。

### **Linux**
- Clang 3.9以降。
- GCC 6.1以降。
- CMake 3.18以降。

### **macOS**
- Xcode 13.4以降。

## **よくある質問**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は[作成](/slides/ja/cpp/create-presentation/)、変更、[変換](/slides/ja/cpp/convert-presentation/)、および[レンダリング](/slides/ja/cpp/convert-powerpoint-to-png/)のためのスタンドアロンエンジンです。

**正しいレンダリングのために必要なフォントは何ですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/cpp/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることをお勧めします。

**カスタムフォントが Linux でフォールバックや文字欠損として表示されるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。name テーブルレコードが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすることで問題は解決します。