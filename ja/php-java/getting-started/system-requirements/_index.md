---
title: システム要件
type: docs
weight: 60
url: /ja/php-java/system-requirements/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のシステム要件を確認してください。Windows、Linux、macOS での PowerPoint および OpenDocument のシームレスなサポートを実現します。"
---
## **はじめに**

Aspose.Slides for PHP via Java は Microsoft PowerPoint などのサードパーティ製品のインストールを必要としません。Aspose.Slides 自体は、Microsoft PowerPoint プレゼンテーション形式を含むさまざまな形式のドキュメントを作成、変更、変換、レンダリングするエンジンです。

## **サポート対象 OS**

Aspose.Slides for Java は、Java ランタイムが動作する 32 ビットまたは 64 ビットの OS ならすべてサポートします（以下に例を示します）。

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

## **FAQ**

**変換やレンダリングに Microsoft PowerPoint のインストールは必要ですか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は単体で動作するエンジンで、プレゼンテーションの[作成](/slides/ja/php-java/create-presentation/)、変更、[変換](/slides/ja/php-java/convert-presentation/)、および[レンダリング](/slides/ja/php-java/convert-powerpoint-to-png/)を行えます。

**正しくレンダリングするために必要なフォントは何ですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/php-java/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることを推奨します。

**Linux でカスタムフォントがフォールバックや文字欠損として表示されるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。名前テーブルが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすることで問題は解決します。