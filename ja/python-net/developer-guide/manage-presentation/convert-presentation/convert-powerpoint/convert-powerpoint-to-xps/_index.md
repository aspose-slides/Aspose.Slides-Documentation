---
title: PythonでPowerPointプレゼンテーションをXPSに変換
linktitle: PowerPointからXPSへ
type: docs
weight: 70
url: /ja/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからXPSへ
- プレゼンテーションをXPSへ
- PPTをXPSへ
- PPTXをXPSへ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint の PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常によく似たファイルを出力することで、コンテンツを印刷できます。XPS 形式は XML に基づいています。XPS ファイルのレイアウトや構造は、すべての OS やプリンターで同じです。

## Microsoft XPS 形式を使用すべきとき

{{% alert color="primary" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法は、[この無料オンライン変換アプリ](https://products.aspose.app/slides/conversion)で確認できます。

{{% /alert %}} 

ストレージコストを削減したい場合、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換すると、保存、共有、印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS の強力なサポートを継続的に実装しているため、この形式でファイルを保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーは利用できるが、PDF への印刷機能はなし。 

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーなし。PDF への印刷機能なし。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF への印刷操作のサポートを実装しました。それ以前は、ユーザーは XPS 形式で文書を印刷することが想定されていました。

## Aspose.Slides を使用した XPS 変換

.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用して、プレゼンテーション全体を XPS 文書に変換できます。

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) を使用しない）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) を使用）

### **デフォルト設定でプレゼンテーションを XPS に変換する**

以下の Python サンプルコードは、標準設定でプレゼンテーションを XPS 文書に変換する方法を示しています:
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
pres = slides.Presentation("Convert_XPS.pptx")

# プレゼンテーションを XPS ドキュメントとして保存する
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **カスタム設定でプレゼンテーションを XPS に変換する**

以下のサンプルコードは、カスタム設定でプレゼンテーションを XPS 文書に変換する方法を Python で示しています:
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
pres = slides.Presentation("Convert_XPS_Options.pptx")

# TiffOptions クラスをインスタンス化する
options = slides.export.XpsOptions()

# メタファイルを PNG として保存する
options.save_metafiles_as_png = True

# プレゼンテーションを XPS ドキュメントとして保存する
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```


## **FAQ**

**XPS をファイルではなくストリームに保存できますか？**

はい。Aspose.Slides はストリームへの直接エクスポートをサポートしており、Web API、サーバーサイドパイプライン、またはファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に引き継がれますか？除外できますか？**

デフォルトでは、通常の（表示されている）スライドのみがレンダリングされます。非表示スライドの [含めるか除外するか](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) は、XPS に保存する前の [エクスポート設定](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) で制御でき、出力に意図したページだけを含めることができます。