---
title: プレゼンテーションにスライドを追加する
type: docs
weight: 20
url: /ja/net/adding-slide-to-presentation/
---

## **OpenXML プレゼンテーション**
以下の機能では、デフォルトでスライドがプレゼンテーションに追加されます。ここでは、インデックス2にテキストを含む新しいスライドを追加しています。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "プレゼンテーションにスライドを追加.pptx";

InsertNewSlide(FileName, 1, "私の新しいスライド");

// 指定のプレゼンテーションにスライドを挿入します。

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // ソース文書を読み書きとして開きます。 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // ソース文書と挿入するスライドの位置とタイトルを次のメソッドに渡します。

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// 指定された位置に指定されたスライドをプレゼンテーションに挿入します。

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // プレゼンテーションが空でないことを確認します。

    if (presentationPart == null)

    {

        throw new InvalidOperationException("プレゼンテーション文書は空です。");

    }

    // 新しいスライドを宣言し、インスタンス化します。

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // スライドの内容を構築します。            

    // 新しいスライドの非視覚的プロパティを指定します。

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // 新しいスライドのグループシェイププロパティを指定します。

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // 新しいスライドのタイトルシェイプを宣言し、インスタンス化します。

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // タイトルシェイプに必要なシェイププロパティを指定します。 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "タイトル" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // タイトルシェイプのテキストを指定します。

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // 新しいスライドの本文シェイプを宣言し、インスタンス化します。

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // 本文シェイプに必要なシェイププロパティを指定します。

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "コンテンツプレースホルダー" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // 本文シェイプのテキストを指定します。

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // 新しいスライドのスライド部分を作成します。

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // 新しいスライド部分を保存します。

    slide.Save(slidePart);

    // プレゼンテーション部分のスライドIDリストを修正します。

    // スライドIDリストはnullであってはなりません。

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // 現在のリストで最大のスライドIDを見つけます。

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // 前のスライドのIDを取得します。

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // 前のスライドと同じスライドレイアウトを使用します。

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // 新しいスライドを前のスライドの後にスライドリストに挿入します。

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // 修正されたプレゼンテーションを保存します。

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
各PowerPointプレゼンテーションファイルには、1つの**メインマスター スライド**とその他の**通常のスライド**が含まれます。これは、プレゼンテーションファイルには少なくとも1枚以上のスライドが含まれていることを意味します。スライドのないプレゼンテーションファイルは、Aspose.Slides for .NETではサポートされていないことを知っておくことが重要です。各スライドには特定の位置と**ユニークID**があります。**スライドID**は、マスター スライドの場合は0から255、通常のスライドの場合は256から65535までの範囲です。

Aspose.Slides for .NETでは、開発者は**Presentation**オブジェクトが公開している**AddEmptySlide**メソッドを使用して、プレゼンテーションに空のスライドを追加することができます。プレゼンテーションに空のスライドを追加するには、次の手順に従ってください：

- Presentationクラスのインスタンスを作成する
- Presentationオブジェクトが公開しているAddEmptySlideメソッドを呼び出す
- 新しく追加された空のスライドでいくつかの作業を行う
- もう1枚のスライドを追加し、その上にテキストを挿入する
- 最後に、Presentationオブジェクトが公開しているWriteメソッドを使用してPPTファイルを保存する

``` csharp

 string FileName = FilePath + "プレゼンテーションにスライドを追加.pptx";

//PPTファイルを表すPresentationExクラスをインスタンス化します

Presentation pres = new Presentation();

//デフォルトのコンストラクタからプレゼンテーションを作成すると空白のスライドがデフォルトで追加されます

//プレゼンテーションに空のスライドを追加し、その空のスライドの参照を取得します

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//出力をディスクに書き込む

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)