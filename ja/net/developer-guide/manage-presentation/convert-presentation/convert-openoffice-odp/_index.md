---
title: OpenOffice ODPの変換
type: docs
weight: 10
url: /net/convert-openoffice-odp/
keywords: "ODPをPDFに変換, ODPをPPTに変換, ODPをPPTXに変換, ODPをXPSに変換, ODPをHTMLに変換, ODPをTIFFに変換"
description: "Aspose.Slidesを使用して、ODPをPDF、ODPをPPT、ODPをPPTX、ODPをHTMLおよびその他の形式に変換します。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) を使用すると、OpenOffice ODPプレゼンテーションを多くの形式に変換できます。ODPファイルを他のドキュメント形式に変換するために使用されるAPIは、PowerPoint（PPTおよびPPTX）変換操作に使用されるものと同じです。 

以下の例では、ODPドキュメントを他の形式に変換する方法を示しています（ソースODPファイルを変更するだけです）：

- [ODPをHTMLに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODPをPDFに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODPをTIFFに変換](/slides/net/convert-powerpoint-to-tiff/)
- [ODPをSWF Flashに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODPをXPSに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODPをメモ付きPDFに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODPをメモ付きTIFFに変換](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例えば、ODPプレゼンテーションをPDFに変換する必要がある場合、次のように実行できます：

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```



## 異なるアプリケーションでのOpenDocumentプレゼンテーション

OpenDocumentプレゼンテーションファイルがPowerPointで開かれると、元のアプリケーションで作成されたときのフォーマットが欠けている場合があります。これは、OpenDocumentプレゼンテーションアプリとPowerPointアプリが異なる機能やオプションを提供しているためです。

以下は、そのいくつかの違いです：
- PowerPointでは、すべてのテーブルが通常最後に読み込まれ、他の図形に重なる（ODPスライドの形状配置に関係なく）。
- ODPテーブルの画像塗りつぶしはPowerPointではサポートされていません。 
- テキストの垂直回転（270、スタック）および分配アラインメントはLibreOffice/OpenOffice Impressではサポートされていません。
- テキストの画像塗りつぶし、グラデーション塗りつぶし、パターン塗りつぶしはLibreOffice/OpenOffice Impressではサポートされていません。

MS PowerPointとLibreOffice/OpenOffice Impressはリストの扱いが異なります。PowerPointで作成されたODPファイルはLibreOffice/OpenOfficeで正しく開くことができず、その逆も同様です。

この画像は、LibreOffice Impressで作成されたリストの表示を示しています：

![odp-list-example](odp-list-example.png)



**Aspose.Slides**は、ODPリストを保存して、LibreOffice/OpenOffice Impressで正しく表示されるようにします。

[OpenDocument形式とPowerPointについてもっと知る](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/)。