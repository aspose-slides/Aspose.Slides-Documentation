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
- yoruma eriş
- yorumu düzenle
- yoruma yanıtla
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

Bu makale, Aspose.Slides for .NET ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarını kapsar; yorumları yazarlara atama, yorum metnini ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma gibi.

PowerPoint'te yorumlar, slaytlardaki açıklama olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Sunum Açılırken Yorumların Gösterilmesi veya Gizlenmesi istediğinizde, yorumların kendisini değiştirmeden bunu talep etmek için [Show or Hide Comments When Opening a Presentation](/slides/tr/net/presentation-view-properties/).

## **Sunumalara Neden Yorum Eklenir?**

Yorumları, sunumları incelerken geri bildirim sağlamak ve meslektaşlarla iş birliği yapmak için kullanabilirsiniz.

Aspose.Slides for .NET, yorumlarla çalışmak için aşağıdaki API'leri sağlar:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) arabirimi, belirli bir yazarla ilişkili yorumları temsil eder.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) arabirimi, bir yorum hakkında bilgi sağlar; yazar, oluşturulma zamanı, konum ve metin gibi.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) sınıfı, bir yazar hakkında bilgi sağlar; adı, baş harfleri ve ilişkili yorumlar.

## **Slayt Yorumları Ekleme**

Örnek, iki slayt oluşturur ve bir yorum yazarını [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) ile kaydeder. Her slayta bir yorum yerleştirmek için [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) kullanır, ardından o yazar için ilk slaytın yorumlarını [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) ile alır. Konsol, ilk yorumun metnini iki kez gösterir; bu, hem slayt hem de yazar üzerinden erişimi gösterir ve kaydedilen sunum her iki yorumu da içerir.

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

## **Yorum Yazarını Bulma veya Oluşturma**

Aynı sunum tekrar tekrar işlendiğinde, yazar eklemeden önce [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) koleksiyonunu arayın. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) hem adı hem de baş harfleri eşleştirir ve eşleşen yazarların bir dizisini döndürür; eşleşme yoksa boş bir dizi döner. Buna karşılık, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) yalnızca adı arar, baş harfler dikkate alınmaz. Koleksiyonda zaten bulunan bir ad ve baş harf ile [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) çağrısı bir istisna fırlatır.

Örnek, en az bir slaytı olan bir sunum dosyası gerektirir. İki geçişin her birinde, ilk eşleşen yazar yeniden kullanılur veya sonuç boşsa yeni bir yazar oluşturulur. Birden çok eşleşme varsa, diğer yazarları birleştirmeden veya kaldırmadan ilk dizi elemanı seçilir. Ardından seçilen yazar için [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) çağrılır ve sunum kaydedilir. İkinci geçiş, birinci geçişin çıktısını açar ve işlemi tekrarlar.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

İkinci geçiş, başka bir yazar eklemeden veya mevcut yorumları kaldırmadan yeni bir yorum ekler. Son dosya, `review_pass_2.pptx`, hem yeni yorumları hem de olası orijinal yorumları içerir. Bir yazarın yeniden kullanılması yorumların tekilleştirilmesini sağlamaz: aynı yorumun tekrar eklenmesini önlemek için eklemeden önce ayrı bir yinelenen kontrolü uygulayın.

## **Slayt Yorumlarına Erişim**

Örnek, mevcut bir sunumu açar ve [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) koleksiyonunu okur. Her yazar için, [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) üzerinden döner ve slayt numarasını, yorum metnini, yazar adını ve oluşturulma zamanını yazar. Girdi sunumu, konsol çıktısı üretmek için yorumlar içermelidir.

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

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) arabirimindeki [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) özelliği, bir yorumun üst yorumunu almanıza veya ayarlamanıza izin verir.

Örnek, iki yazarın yorumlarını oluşturur ve [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) kullanarak yanıtları, bir yanıtın başka bir yanıta yanıt vermesi dahil olmak üzere, oluşturur. `null` geçildiğinde [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) tüm yazarların yorumlarını getirir; konsol her girişi yanıt hiyerarşisinin derinliğine göre girintiler. Örnek, tam tartışmayı kaydeder, ilk kök yorum üzerinde [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) çağırır ve bu yorum ve yanıtları kaldırılmış ikinci bir sunum kaydeder.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) arabiriminin [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) yöntemi bir yorumu silerken, o yoruma ait tüm yanıtlar da silinir.
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) özelliği dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir AutoShape içindeki metin aralığına ilişkilendirilebilir. [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretçi koordinatlarına ek olarak bir [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) argümanı kabul eder.

`null` şekil argümanı sağlandığında yorum, slayt‑seviyesinde bir yorum olur. İşaretçi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir; bu nedenle [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` döner. Bir [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) sağlandığında yorum o şekle sabitlenir. Koordinatlar, yorum işaretçisinin slayttaki konumunu tanımlamaya devam ederken, şekil ilişkisi [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) ile alınabilir.

### **Modern Yorumu Bir Şekle Sabitleme**

Örnek, [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) yöntemini iki kez çağırır: bir kez `null` şekil ile slayt‑seviyesi yorum, bir kez de dikdörtgeni çapa olarak kullanarak. [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) okununca slayt‑seviyesi yorum için `True` ve çapa yapılan yorum için `Revenue title` yazdırılır. Her iki yorum da sunumla kaydedilir.

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

### **Farklı Şekil Türlerine Yorum Sabitleme**

[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) uygulayan herhangi bir slayt nesnesi şekil çapa olarak kullanılabilir. Yaygın örnekler arasında [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) ve [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) (ör. grafikler) bulunur.

Örnek, beş şekil türüne (AutoShape, resim çerçevesi, grup, bağlayıcı ve grafik) her biri için bir modern yorum ilişkilendirmek amacıyla [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) kullanır. Resim gömülü görüntü verisiyle sağlanır, dış bir resim gerekli değildir. Her yorumun kendi işaretçi konumu vardır ve kaydedilen sunum beş şekil ilişkisini de tutar.

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

### **Metne Yorum Sabitleme ve Durumunu Ayarlama**

[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ile ilişkilendirilmiş bir modern yorumda, [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) şeklin metin çerçevesindeki seçili metnin başlangıç konumunu, [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) ise seçimin uzunluğunu belirler. Bu iki özellik, yorumu AutoShape içinde belirli bir metin aralığıyla ilişkilendirir.

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) özelliği, [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) enum değerlerinden biriyle okunabilir veya güncellenebilir:

- `NotDefined` — belirli bir modern‑yorum durumu tanımlı değildir.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Örnek, bir dikdörtgenin metnindeki "quarterly revenue" kelimelerine modern bir yorum sabitler. Metinden sıfır‑bazlı [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) hesaplanır ve [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) seçili karakter sayısına ayarlanır. [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) `Resolved` olarak ayarlandıktan sonra sunum kaydedilir ve yeniden açılır. Dört konsol kontrolü her biri `True` yazdırmalı, şekil çapasının, metin aralığının ve durumun korunduğunu onaylamalıdır.

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

Örnek, modern yorumlar içeren mevcut bir sunum gerektirir ve yorumların metnini, durumunu ve çapa ayrıntılarını yazdırır. İncelemek için, hangi yorumların [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) uyguladığını kontrol edin, ardından [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) ve [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) incelenir. `null` şekil, slayt‑seviyesi yorum olduğunu gösterir. Bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) çapasında, metin‑seçim özellikleri şeklin metin çerçevesindeki ilgili aralığı tanımlar.

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

## **Yorumları Kaldırma**

Aspose.Slides for .NET, bir sunumdan tüm yorumları ve yazarlarını kaldırmanıza veya seçili yorumları silip geri kalanını tutmanıza olanak tanır. Aşağıdaki örnekler her iki yaklaşımı gösterir ve güncellenmiş sunumu kaydeder.

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Örnek, mevcut bir sunumu açar ve her yazar için [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) metodunu çağırır, ardından yazarları kendilerini kaldırmak için [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) metodunu çağırır. Kaydedilen sunum ne yorum ne de yorum yazarları içerir. Kaldırmayı gözlemlemek için yorumlar içeren bir sunum kullanın.

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

### **Belirli Yorumları Kaldırma**

Örnek, bir slaytta iki yorum oluşturur ve [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) kullanarak her yazarın yorumlarını bulur. Metni "comment 1" olan yorumları toplar ve ardından [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) metodunu çağırır; bu, seçim sırasında koleksiyonun değiştirilmesini önler. Kaydedilen sunum yalnızca "comment 2" yorumunu tutar.

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

**Aspose.Slides modern yorumlar için çözülmüş (resolved) durumunu destekliyor mu?**

Evet. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) bir [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) değeriyle okunabilir ve ayarlanabilir; `Resolved` da dahildir. Durum sunumda saklanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İleti zincirleri (yanıt dizileri) destekleniyor mu ve bir iç içe limit var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) referansı ile bir yanıt zinciri oluşturabilir. API, belirli bir iç içe derinlik limiti tanımlamaz.

**Bir yorum işaretçisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

İşaretçi konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; bu, işaretçiyi slayt üzerinde kesin olarak konumlandırmanızı sağlar.