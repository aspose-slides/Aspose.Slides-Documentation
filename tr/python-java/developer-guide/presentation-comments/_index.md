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

Bu makale, Aspose.Slides for Python via Java kullanarak sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarını kapsar; örneğin yorumları yazarlara atama, yorum metni ve meta verileri okuma, yanıt zincirleri oluşturma ve seçili yorumları veya tüm yorumları kaldırma.

PowerPoint'te yorumlar, slaytlardaki ek açıklamalar olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve iş arkadaşlarınızla iş birliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Python via Java, yorumlarla çalışmak için aşağıdaki API'leri sunar:

* The [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [CommentCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentcollection/) sınıfı, belirli bir yazarla ilişkili yorumları temsil eder.
* The [Comment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/) sınıfı, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin gibi bilgiler sağlar.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentauthor/) sınıfı, bir yazarın adı, baş harfleri ve ilişkili yorumları dahil olmak üzere bilgiler sunar.

## **Slayt Yorumları Ekleme**

Aşağıdaki örnek, bir PowerPoint sunumunda slaytlara yorum eklemenin nasıl yapılacağını gösterir:

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

Aşağıdaki örnek, bir PowerPoint sunumunda mevcut yorumlara nasıl erişileceğini gösterir:

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

Bir ana yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. The [Comment.getParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#getParentComment) ve [Comment.setParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#setParentComment) metodları, bir yorumun ebeveynini almanıza veya ayarlamanıza olanak tanır.

Aşağıdaki örnek, yanıt eklemeyi ve ortaya çıkan yorum hiyerarşisini incelemeyi gösterir:

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
* [Comment.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#remove) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [Comment.setParentComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#setParentComment) döngüsel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) içindeki metin aralığına ilişkilendirilebilir. The [CommentCollection.addModernComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentcollection/#addModernComment) yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) argümanı kabul eder.

`None` şekil argümanı olarak geçirildiğinde, yorum bir slayt‑seviyesinde yorum olur. İşaretleyici sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir, bu yüzden [ModernComment.getShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getShape) `None` döndürür. Bir [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sağlandığında, yorum o şekle sabitlenir. Koordinatlar hâlâ yorum işaretleyicisinin slayttaki konumunu tanımlar, şekil ilişkilendirmesi ise [ModernComment.getShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getShape) aracılığıyla elde edilebilir.

### **Modern Yorumu Bir Şekle Bağlama**

Aşağıdaki örnek, bir slayt‑seviyesinde modern yorum ve belirli bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) üzerine sabitlenmiş bir modern yorum oluşturur. Ardından her iki yorumdan da ilişkili şekli okur.

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

### **Yorumları Farklı Şekil Türlerine Bağlama**

[Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türetilen herhangi bir slayt nesnesi şekil sabitleyicisi olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/python-java/aspose.slides/connector/) ve grafik nesneleri (örneğin grafikler) bulunur.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her birine modern bir yorum ilişkilendirir.

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

### **Yorumu Metne Bağlama ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ile ilişkili modern yorum için, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getTextSelectionStart) ve [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#setTextSelectionStart) şeklin metin çerçevesindeki seçili metnin başlangıç konumuna erişir. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getTextSelectionLength) ve [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#setTextSelectionLength) seçim uzunluğunu verir. Bu iki değer birlikte, yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[ModernComment.getStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getStatus) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#setStatus) metodları, [ModernCommentStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/) sabitlerinden bir değere erişir:

- [NotDefined](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#NotDefined) — belirli bir modern‑yorum durumu tanımlanmamıştır.
- [Active](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Active) — yorum aktiftir.
- [Resolved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Resolved) — yorum çözülmüştür.
- [Closed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/#Closed) — yorum kapatılmıştır.

Aşağıdaki örnek, bir şekle sabitlenmiş modern yorum oluşturur, onu bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosya yeniden açıldıktan sonra değerleri doğrular.

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

Mevcut bir sunumu incelemek için, hangi yorumların [ModernComment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/) örnekleri olduğunu kontrol edin, ardından [ModernComment.getShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getTextSelectionLength) ve [ModernComment.getStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getStatus) metodlarına bakın. `None` bir şekil, slayt‑seviyesinde bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) sabitleyicisi için, metin‑seçim metodları şeklin metin çerçevesindeki ilgili aralığı tanımlar.

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

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını nasıl kaldıracağınızı gösterir:

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

Aşağıdaki örnek, bir slayttan belirli yorumları nasıl kaldıracağınızı gösterir:

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

**Aspose.Slides modern yorumlar için çözülmüş (resolved) durumunu destekliyor mu?**

Evet. [ModernComment.getStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#getStatus) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncomment/#setStatus) yöntemleri, `Resolved` dahil olmak üzere bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/python-java/aspose.slides/moderncommentstatus/) değerine erişir. Durum sunumda saklanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir derinlik sınırı var mı?**

Evet. Her yorum, yanıt zincirlerini etkinleştiren bir [parent comment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/comment/#getParentComment) referansına sahip olabilir. API, belirli bir iç içeleme derinliği sınırlaması tanımlamaz.

**Bir yorum işaretleyicisinin slayttaki konumu hangi koordinat sistemine göre tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; bu sayede işaretleyiciyi slayt üzerinde hassas bir şekilde konumlandırabilirsiniz.