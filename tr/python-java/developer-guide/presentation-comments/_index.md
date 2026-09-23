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
- yorumu düzenle
- yoruma yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorumları ekleyin, okuyun, düzenleyin, yanıtlayın ve hızlı ve kolay bir şekilde kaldırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarını kapsar; yorumları yazarlara atama, yorum metni ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma gibi.

PowerPoint'te yorumlar slaytlarda ek açıklama olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Yorumların kendileri değişmeden bir sunum açıldığında gösterilmesi veya gizlenmesi isteniyorsa, bkz. [Sunum Açılırken Yorumları Göster veya Gizle](/slides/tr/python-java/presentation-view-properties/).

## **Sunumlara Neden Yorum Eklenir?**

Yorumları, sunumları incelerken geri bildirim sağlamak ve meslektaşlarla iş birliği yapmak için kullanabilirsiniz.

Aspose.Slides for Python via Java, yorumlarla çalışmak için aşağıdaki API'leri sunar:

* The [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [CommentCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentcollection/) sınıfı, bireysel bir yazarla ilişkili yorumları temsil eder.
* The [Comment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/) sınıfı, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin gibi bilgileri sağlar.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentauthor/) sınıfı, yazar hakkında isim, baş harfler ve ilişkili yorumlar gibi bilgiler verir.

## **Slayt Yorumları Ekle**

PowerPoint sunumunda slaytlara yorum eklemenin örneği aşağıdadır:

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

## **Slayt Yorumlarına Erişim**

PowerPoint sunumunda mevcut yorumlara nasıl erişileceğini gösteren örnek aşağıdadır:

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

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment.getParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#getParentComment) ve [Comment.setParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#setParentComment) yöntemleri bir yorumun üst yorumunu almanıza veya ayarlamanıza izin verir.

Yanıtlar ekleme ve ortaya çıkan yorum hiyerarşisini inceleme örneği aşağıdadır:

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
* [Comment.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#remove) yöntemi bir yorumu silmek için kullanıldığında, o yorumun tüm yanıtları da silinir.
* [Comment.setParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#setParentComment) bir döngüsel referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekle**

Modern yorumlar slaytın kendisiyle, belirli bir şekille veya bir [AutoShape] içindeki metin aralığıyla ilişkilendirilebilir. [CommentCollection.addModernComment] yöntemi, slayt ve yorum işaretçisi koordinatlarının yanı sıra bir [Shape] parametresi alır.

`shape` parametresi için `None` geçirildiğinde yorum, slayt düzeyinde bir yorum olur. İşaretçi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekille ilişkilendirilmez; bu nedenle [ModernComment.getShape] `None` döndürür. Bir [Shape] sağlandığında yorum o şekle sabitlenir. Koordinatlar yine de yorum işaretçisinin slayt üzerindeki konumunu tanımlar, şekil ilişkisi ise [ModernComment.getShape] aracılığıyla alınabilir.

### **Modern Yorumları Bir Şekle Sabitleme**

Aşağıdaki örnek, hem slayt düzeyinde bir modern yorum hem de belirli bir [AutoShape]'a sabitlenmiş bir modern yorum oluşturur. Ardından her yorumdan ilişkili şekli okur.

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

[Shape] sınıfından türeten herhangi bir slayt nesnesi şekil bağlantısı olarak kullanılabilir. Yaygın örnekler arasında [AutoShape], [PictureFrame], [GroupShape], [Connector] ve grafik nesneleri (ör. grafikler) yer alır.

Aşağıdaki örnek birkaç yaygın şekil türü oluşturur ve her biriyle bir modern yorum ilişkilendirir.

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

### **Yorumu Metne Sabitle ve Durumunu Ayarla**

Bir [AutoShape] ile ilişkili modern bir yorum için, [ModernComment.getTextSelectionStart] ve [ModernComment.setTextSelectionStart] şeklin metin çerçevesindeki seçili metnin başlangıç konumunu alır. [ModernComment.getTextSelectionLength] ve [ModernComment.setTextSelectionLength] seçimin uzunluğunu alır. Bu değerler birlikte yorumu AutoShape içindeki belirli bir metin aralığına bağlar.

[ModernComment.getStatus] ve [ModernComment.setStatus] yöntemleri [ModernCommentStatus] sabitlerinden bir değere erişir:

- [NotDefined](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#NotDefined) — Belirli bir modern yorum durumu tanımlanmamış.
- [Active](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Active) — Yorum aktiftir.
- [Resolved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Resolved) — Yorum çözülmüş olarak işaretlenmiştir.
- [Closed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Closed) — Yorum kapatılmıştır.

Aşağıdaki örnek, şekle sabitlenmiş bir modern yorum oluşturur, onu bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosyayı yeniden açtıktan sonra değerleri doğrular.

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

Mevcut bir sunumu incelemek için, hangi yorumların [ModernComment] örneği olduğunu kontrol edin, ardından [ModernComment.getShape], [ModernComment.getTextSelectionStart], [ModernComment.getTextSelectionLength] ve [ModernComment.getStatus] elemanlarını inceleyin. `None` şekil bir slayt düzeyinde yorum olduğunu gösterir. Bir [AutoShape] bağlantısı için metin seçimi yöntemleri, şeklin metin çerçevesindeki ilişkili aralığı belirler.

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

## **Yorumları Kaldır**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldır**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını kaldırmanın nasıl yapılacağını gösterir:

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

### **Belirli Yorumları Kaldır**

Aşağıdaki örnek, bir slayttan belirli yorumları kaldırmanın nasıl yapılacağını gösterir:

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

## **FAQ**

**Aspose.Slides modern yorumlar için çözülmüş durumunu destekliyor mu?**

Evet. [ModernComment.getStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getStatus) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#setStatus) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/) değerine (ör. `Resolved`) erişir. Durum sunumda depolanır ve dosya yeniden açıldığında tekrar okunabilir.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, bir [parent comment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#getParentComment) referansı içerebilir, bu da yanıt zincirlerini mümkün kılar. API belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir slayttaki yorum işaretçisinin konumu hangi koordinat sisteminde tanımlanır?**

İşaretçi konumu, slayt koordinat sistemindeki kayan nokta (floating‑point) koordinatlarla tanımlanır; böylece işaretçiyi slayt üzerinde tam olarak konumlandırabilirsiniz.