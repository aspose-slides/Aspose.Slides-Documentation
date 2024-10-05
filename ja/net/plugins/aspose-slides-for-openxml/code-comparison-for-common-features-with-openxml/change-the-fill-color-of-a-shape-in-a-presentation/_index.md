---
title: プレゼンテーション内の図形の塗りつぶし色を変更する
type: docs
weight: 40
url: /net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXMLプレゼンテーション**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// 図形の塗りつぶし色を変更します。

// テストファイルには、最初のスライドの最初の図形として塗りつぶされた図形が必要です。

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // 最初のスライドのリレーションシップIDを取得します。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // リレーションシップIDからスライドパートを取得します。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // 変更する図形を含む図形ツリーを取得します。

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // 図形ツリー内の最初の図形を取得します。

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // 図形のスタイルを取得します。

                ShapeStyle style = shape.ShapeStyle;

                // 塗りつぶしリファレンスを取得します。

                Drawing.FillReference fillRef = style.FillReference;

                // 塗りつぶし色をSchemeColor Accent 6に設定します。

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // 修正されたスライドを保存します。

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
プレゼンテーション内の図形を塗りつぶすには、以下の手順に従う必要があります：

- Presentationクラスのインスタンスを作成します。
- インデックスを使用してスライドのリファレンスを取得します。
- スライドにIShapeを追加します。
- 図形の塗りつぶしタイプをSolidに設定します。
- 図形の色を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//PPTXを表すPresentationExクラスをインスタンス化します。

using (Presentation pres = new Presentation())

{

    //最初のスライドを取得します

    ISlide sld = pres.Slides[0];

    //長方形タイプのオートシェイプを追加します

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //塗りつぶしタイプをSolidに設定します

    shp.FillFormat.FillType = FillType.Solid;

    //長方形の色を設定します

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //PPTXファイルをディスクに書き込みます

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **コード例をダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)