---
title: システム要件
type: docs
weight: 80
url: /ja/java/system-requirements/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のシステム要件をご確認ください。Windows、Linux、macOS での PowerPoint および OpenDocument のシームレスなサポートを確保します。"
---
## **概要**
Aspose.Slides for Java は Microsoft PowerPoint のインストールは必要ありません。Aspose.Slides 自体が Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングエンジンです。

## **サポートされているオペレーティングシステム**
Aspose.Slides for Java は、Java ランタイムが動作する 32 ビットまたは 64 ビットのオペレーティングシステムであれば、以下に限らずすべてサポートします。

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu、OpenSUSE、CentOS など)

### **Mac**
- Mac OS X

## **サポートされている Java バージョン**
Aspose.Slides for Java は J2SE 6.0（Java 1.6）以降をサポートします。

## **よくある質問**

**変換やレンダリングのために Microsoft PowerPoint のインストールは必要ですか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides はプレゼンテーションの[作成](/slides/ja/java/create-presentation/)、変更、[変換](/slides/ja/java/convert-presentation/)、および[レンダリング](/slides/ja/java/convert-powerpoint-to-png/)のためのスタンドアロンエンジンです。

**正しいレンダリングのために必要なフォントはどれですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/java/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するため、一般的なフォントパッケージをインストールすることが推奨されます。

**カスタムフォントが Linux でフォールバックまたは欠落したテキストとして表示されるのはなぜですか？**

フォントファイルに不整合または破損した name-table エントリがある場合、Linux のフォントマッチングスタック（FreeType/fontconfig）は無効なレコードを選択し、フォントが解決できなくなります。name-table レコードが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすれば問題は解消されます。