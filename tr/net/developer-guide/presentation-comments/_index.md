---
title: .NET'te Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/net/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma erişim
- yorumu düzenle
- yoruma yanıt
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve işbirliği senaryolarını kapsar; yazarlarına yorum atama, yorum metni ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları veya tüm yorumları kaldırma gibi.

PowerPoint'te yorumlar, slaytlardaki açıklama balonları olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

[Sunumu Açarken Yorumları Göster veya Gizle](/slides/tr/net/presentation-view-properties/).

## **Sunumlara Neden Yorum Eklenir?**

Yorumları, sunumları incelerken geri bildirim sağlamak ve meslektaşlarla işbirliği yapmak için kullanabilirsiniz.

Aspose.Slides for .NET aşağıdaki API'leri yorumlarla çalışmak için sağlar:

* The [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [ICommentCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icommentcollection) arayüzü, bireysel bir yazarla ilişkili yorumları temsil eder.
* The [IComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment) arayüzü, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin dahil bilgi sağlar.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/net/aspose.slides/commentauthor) sınıfı, bir yazar hakkında ad, baş harfler ve ilişkili yorumlar gibi bilgi sağlar.

## **Slayt Yorumları Ekle**

PowerPoint sunumundaki slaytlara yorum eklemeyi gösteren örnek:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Slayt Yorumlarına Erişme**

PowerPoint sunumundaki mevcut yorumlara erişmeyi gösteren örnek:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Yorumlara Yanıt Verme**

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [IComment] arayüzünün [ParentComment] özelliği, bir yorumun üst yorumunu almanızı veya ayarlamanızı sağlar.

Aşağıdaki örnek, yanıt eklemeyi ve oluşan yorum hiyerarşisini incelemeyi gösterir:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Bir yorumu silmek için [IComment] arayüzünün [Remove] yöntemi kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* ParentComment özelliği döngüsel bir referans oluşturursa, bir [PptxEditException] istisnası fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekle**

Modern yorumlar slaytın kendisine, belirli bir şekle veya AutoShape içindeki bir metin aralığına ilişkilendirilebilir. [ICommentCollection.AddModernComment] yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [IShape] bağımsız değişkeni kabul eder.

Şekil bağımsız değişkeni için `null` geçirilirse, yorum slayt seviyesinde bir yorum olur. İşaretleyicisi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir, bu yüzden [IModernComment.Shape] `null` döner. Bir [IShape] sağlandığında, yorum o şekle bağlanır. Koordinatlar yine slayt üzerindeki yorum işaretleyicisinin konumunu tanımlar, şekil ilişkisi ise [IModernComment.Shape] üzerinden alınabilir.

### **Modern Yorumu Bir Şekle Bağlama**

Bu örnek, hem slayt seviyesinde bir modern yorum hem de belirli bir AutoShape'e bağlanmış bir modern yorum oluşturur. Ardından her yorumdan ilişkili şekli okur.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Yorumları Farklı Şekil Türlerine Bağlama**

Yorum bağlama için kullanılabilecek herhangi bir slayt nesnesi [IShape] arayüzünü uygular. Yaygın örnekler arasında [IAutoShape], [IPictureFrame], [IGroupShape], [IConnector] ve grafik nesneleri (ör. grafikler) bulunur.

Bu örnek, çeşitli yaygın şekil türleri oluşturur ve her birine modern bir yorum ilişkilendirir.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Yorumu Metne Bağla ve Durumunu Ayarla**

Bir [IAutoShape] ile ilişkili modern yorum için, [IModernComment.TextSelectionStart] seçilen metnin şeklin metin çerçevesindeki başlangıç konumunu, [IModernComment.TextSelectionLength] ise seçimin uzunluğunu belirtir. Bu iki özellik birlikte, yorumu AutoShape içindeki belirli bir metin aralığına bağlar.

[IModernComment.Status] özelliği, bir [ModernCommentStatus] değerinden okunabilir veya ayarlanabilir:

- `NotDefined` — belirli bir modern yorum durumu tanımlanmadı.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüş durumdadır.
- `Closed` — yorum kapalıdır.

Bu örnek, şekle bağlanmış bir modern yorum oluşturur, metin seçimiyle ilişkilendirir, durumu çözülmüş olarak işaretler, sunumu kaydeder ve dosyayı yeniden açtıktan sonra değerleri doğrular.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Mevcut Modern Yorumları İnceleme**

Var olan bir sunumu incelemek için, hangi yorumların [IModernComment] uyguladığını kontrol edin, ardından [IModernComment.Shape], [IModernComment.TextSelectionStart], [IModernComment.TextSelectionLength] ve [IModernComment.Status] özelliklerine bakın. `null` şekil bir slayt düzeyi yorumu gösterir. Bir [IAutoShape] bağlaması için, metin seçim özellikleri şeklin metin çerçevesindeki ilgili aralığı tanımlar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Yorumları Kaldır**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldır**

Bu örnek, bir sunumdan tüm yorumları ve yorum yazarlarını kaldırmayı gösterir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Belirli Yorumları Kaldır**

Bu örnek, bir slayttan belirli yorumları kaldırmayı gösterir.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş durumunu destekliyor mu?**

Evet. [IModernComment.Status] bir [ModernCommentStatus] değeriyle, `Resolved` dahil, okunabilir ve ayarlanabilir. Durum sunumda saklanır ve dosya yeniden açıldığında tekrar okunabilir.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [parent comment] referansı ile bir yanıt zinciri oluşturabilir. API belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir yorum işaretleyicisinin konumu slayt üzerinde hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır, bu da onu slayt üzerinde kesin olarak konumlandırmanıza olanak tanır.