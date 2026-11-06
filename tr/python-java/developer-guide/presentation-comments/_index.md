---
title: Python üzerinden Java ile Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/python-java/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorum düzenle
- yoruma yanıtla
- yorum kaldır
- yorum sil
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumla ilgili ana tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma işlemlerini gösterir.

Örnekler, PowerPoint’te yaygın inceleme ve iş birliği senaryolarını kapsar; örneğin yorumları yazarlara atama, yorum metnini ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları veya tüm yorumları kaldırma.

PowerPoint’te yorumlar, slaytlardaki ek açıklamalar olarak görünür. Bir yorumu seçtiğinizde metni ve ilgili tartışma görüntülenir.

Sunum açıldığında yorumların gösterilmesini veya gizlenmesini, yorumların kendisini değiştirmeden ayarlamak için [Show or Hide Comments When Opening a Presentation](/slides/tr/python-java/presentation-view-properties/) bölümüne bakın.

## **Sunumlara Yorum Eklemek Neden Önemli?**

Yorumları, sunumları incelerken geri bildirim sağlamak ve meslektaşlarla iş birliği yapmak için kullanabilirsiniz.

Aspose.Slides for Python via Java, yorumlarla çalışmak için aşağıdaki API’leri sunar:

* [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) sınıfı, belirli bir yazarla ilişkili yorumları temsil eder.
* [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) sınıfı, bir yorum hakkında yazar, oluşturma zamanı, konum ve metin gibi bilgileri sunar.
* [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) sınıfı, yazarın adı, baş harfleri ve ilişkili yorumlar gibi bilgileri sağlar.

## **Slayt Yorumları Ekleme**

Örnek, iki slayt oluşturur ve bir yorum yazarını [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) ile kaydeder. Her slayta bir yorum yerleştirmek için [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) kullanır, ardından o yazar için ilk slaydın yorumlarını [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) ile alır. Konsol, ilk yorumun metnini iki kez gösterir; bu, slayt ve yazar üzerinden erişimin bir örneğidir ve kaydedilen sunum her iki yorumu da içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yorum Yazarını Bulma veya Oluşturma**

Aynı sunumu tekrar tekrar otomatik inceleme sürecine tabi tutarken, bir yazar eklemeden önce [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) tarafından döndürülen koleksiyonda arama yapın. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) hem adı hem de baş harfleri eşleştirir ve eşleşen yazarların bir dizisini döndürür; eşleşme yoksa boş bir dizi döner. Buna karşılık, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) sadece ada göre arama yapar, baş harfleri göz ardı eder. Koleksiyonda zaten bulunan bir ad ve baş harfle [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) çağrısı bir istisna fırlatır.

Örnek, en az bir slayt içeren bir sunum dosyası gerektirir. İki geçişin her birinde, önceki geçişte bulunan ilk eşleşen yazar yeniden kullanılır veya sonuç boşsa yeni bir yazar oluşturulur. Birden fazla eşleşme varsa, diğer yazarları birleştirmeden veya kaldırmadan ilk dizi öğesi seçilir. Ardından seçilen yazar için [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) çağrılır ve sunum kaydedilir. İkinci geçiş, birinci geçişin çıktısını açar ve işlemi tekrar eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

İkinci geçiş, başka bir yazar eklemeden veya mevcut yorumları kaldırmadan yeni bir yorum ekler. Son dosya, `review_pass_2.pptx`, her iki yeni yorumu da orijinal yorumlarla birlikte içerir. Bir yazarın yeniden kullanılması yorumların tekrarlanmasını önlemez: aynı yorumu tekrar eklemeyi önlemek için eklemeden önce ayrı bir çoğaltma kontrolü uygulayın.

## **Slayt Yorumlarına Erişim**

Örnek, mevcut bir sunumu açar ve [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) tarafından döndürülen koleksiyonu okur. Her yazar için, [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) tarafından döndürülen koleksiyonda dolaşır ve slayt numarasını, yorum metnini, yazar adını ve oluşturma zamanını yazdırır. Girdi sunumu, konsol çıktısı almak için yorum içermelidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Yorumlara Yanıt Verme**

Bir üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) ve [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) yöntemleri, bir yorumun üst yorumunu almanıza veya ayarlamanıza olanak tanır.

Örnek, iki yazar tarafından oluşturulan yorumları [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) kullanarak yanıtlama zinciri oluşturur; bir yanıt diğer bir yanıta yanıt olarak eklenir. `None` değerini [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) metoduna geçirerek tüm yazarların yorumları alınır; konsol, yanıt hiyerarşisindeki derinliğe göre her girişi girintiler. Örnek, tam tartışmayı kaydeder, ilk kök yorumu [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) metoduyla siler ve bu yorum ve yanıtları kaldırılmış ikinci bir sunum kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) bir döngüsel referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) içindeki bir metin aralığına ilişkilendirilebilir. [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) yöntemi, slayt ve yorum işaretleyici koordinatlarının yanı sıra bir [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) argümanı da kabul eder.

`None` şekil argümanı geçildiğinde, yorum bir slayt‑seviyesi yorum olur. İşaretçi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir; bu nedenle [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) `None` döndürür. Bir [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sağlandığında, yorum o şekle sabitlenir. Koordinatlar hâlâ yorum işaretleyicisinin slayttaki konumunu tanımlar; şekil ilişkisi ise [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) ile alınabilir.

### **Modern Yorumu Bir Şekle Sabitleme**

Örnek, [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) yöntemini iki kez çağırır: bir kez `None` şekil ile slayt‑seviyesi yorum ve bir kez dikdörtgeni çapa olarak kullanır. [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) okunması, slayt‑seviyesi yorumun `None` kontrolü için `True` ve çapa yorum için `Revenue title` çıktısını verir. Her iki yorum da sunumla birlikte kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Yorumları Farklı Şekil Türlerine Sabitleme**

[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sınıfından türeyen herhangi bir slayt nesnesi şekil çapa olarak kullanılabilir. Yaygın örnekler şunlardır: [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) ve [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) (örneğin grafikler).

Örnek, beş farklı şekil türüyle ilişkilendirilmiş bir yorum eklemek için [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) kullanır: bir AutoShape, bir resim çerçevesi, bir grup, bir bağlayıcı ve bir grafik. Resim gömülü görüntü verisi içerdiği için harici bir resim dosyasına ihtiyaç yoktur. Her yorumun kendi işaretleyici konumu vardır ve kaydedilen sunum beş şekil ilişkilendirmesini de korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Metne Yorum Sabitleme ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ile ilişkilendirilmiş modern yorum için, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) ve [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) şeklin metin çerçevesindeki seçili metnin başlangıç konumuna erişir. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) ve [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) seçimin uzunluğunu alır. Bu iki değer, yorumu AutoShape içindeki belirli bir metin aralığına bağlar.

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) ve [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) sabitlerinden bir değerle çalışır:

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — özel bir modern‑yorum durumu tanımlanmamış.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — yorum aktif.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — yorum çözülmüş.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — yorum kapatılmış.

Örnek, bir dikdörtgenin metnindeki “quarterly revenue” (çeyrek gelir) kelimelerine modern bir yorum sabitler. Metinden sıfır‑tabanlı seçim başlangıcını hesaplar ve bunu [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) metoduna geçirir, ardından seçili karakter sayısını ayarlamak için [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) kullanır. `Resolved` değeriyle [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) çağrıldıktan sonra sunumu kaydeder ve yeniden açar. Dört konsol kontrolü de `True` yazdırmalı, şekil sabitlemesinin, metin aralığının ve durumun korunduğunu doğrulamalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Mevcut Modern Yorumları İnceleme**

Örnek, modern yorumlar içeren mevcut bir sunum gerektirir ve yorumların metnini, durumunu ve sabitleme ayrıntılarını yazdırır. İncelemek için, yorumların [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) örnekleri olup olmadığını kontrol edin, ardından [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) ve [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) metodlarını inceleyin. `None` şekil bir slayt‑seviyesi yorumu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) sabitlemesi için, metin‑seçim metodları şeklin metin çerçevesindeki ilgili aralığı tanımlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Yorumları Kaldırma**

Aspose.Slides for Python via Java, bir sunumdan tüm yorumları ve yazarlarını kaldırmanıza veya seçili yorumları silip geri kalanlarını korumanıza olanak tanır. Aşağıdaki örnekler her iki yaklaşımı gösterir ve güncellenmiş sunumu kaydeder.

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Örnek, mevcut bir sunumu açar ve her yazar için [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) metodunu çağırır, ardından yazarları kendilerini kaldırmak için [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) metodunu kullanır. Kaydedilen sunum ne yorum ne de yorum yazarı içermez. Kaldırmayı gözlemlemek için yorum içeren bir sunum kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Belirli Yorumları Kaldırma**

Örnek, bir slaytta iki yorum oluşturur ve [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) ile her yazarın yorumlarını bulur. [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) çağrılmadan önce metni “comment 1” olan yorumları toplar; bu, seçim sırasında koleksiyonun değiştirilmesini önler. Kaydedilen sunum yalnızca “comment 2” yorumunu tutar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş (resolved) bir durum destekliyor mu?**

Evet. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) ve [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) bir [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) değerine erişir; bu değer `Resolved` durumunu içerir. Durum sunumda saklanır ve dosya yeniden açıldığında tekrar okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu, bir iç içeleme sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) referansı aracılığıyla bir üst yoruma bağlanabilir; bu sayede yanıt zincirleri oluşturulur. API, belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir yorum işaretleyicisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta (floating‑point) koordinatlarla tanımlanır; böylece işaretleyiciyi slayt üzerinde kesin olarak konumlandırabilirsiniz.