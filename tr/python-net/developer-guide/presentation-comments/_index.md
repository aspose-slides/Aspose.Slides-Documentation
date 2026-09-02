---
title: Python'da Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/python-net/presentation-comments/
keywords:
  - yorum
  - modern yorum
  - PowerPoint yorumları
  - sunum yorumları
  - slayt yorumları
  - yorum ekle
  - yorum erişimi
  - yorum düzenle
  - yorum yanıtla
  - yorum kaldır
  - yorum sil
  - PowerPoint
  - sunum
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleme, okuma, düzenleme, yanıtlama ve kaldırma."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma işlemlerini gösterir.

Örnekler, PowerPoint'te yaygın gözden geçirme ve işbirliği senaryolarını kapsar; örneğin yorumları yazarlara atama, yorum metni ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma.

PowerPoint'te yorumlar, slaytların üzerindeki ek açıklamalar olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

## **Sunumalara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve meslektaşlarınızla işbirliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Python via .NET, yorumlarla çalışmak için aşağıdaki API'leri sağlar:

* Sunumun yorum yazarlarına erişim sağlayan [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı.
* Tek bir yazarla ilişkili yorumları temsil eden [CommentCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentcollection/) sınıfı.
* Bir yorum hakkında yazar, oluşturma zamanı, konum ve metin gibi bilgileri sağlayan [Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfı.
* Bir yazar hakkında adı, baş harfleri ve ilişkili yorumlar gibi bilgileri sağlayan [CommentAuthor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentauthor/) sınıfı.

## **Slayt Yorumları Ekleme**

PowerPoint sunumundaki slaytlara yorum eklemenin bir örneği aşağıdadır:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Yorumlarına Erişme**

PowerPoint sunumunda mevcut yorumlara erişmenin bir örneği aşağıdadır:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Yorumlara Yanıt Verme**

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfının [parent_comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/parent_comment/) özelliği, bir yorumun üst yorumunu almanızı veya ayarlamanızı sağlar.

Yanıt ekleme ve oluşan yorum hiyerarşisini incelemenin bir örneği aşağıdadır:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Bir yorumun silinmesi için [Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfının [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/remove/) yöntemi kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [parent_comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/parent_comment/) özelliği döngüsel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) istisnası fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisi, belirli bir şekil veya bir AutoShape içindeki metin aralığı ile ilişkilendirilebilir. [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentcollection/add_modern_comment/) yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) parametresi alır.

`shape` parametresi `None` olarak verildiğinde yorum, slayt düzeyinde bir yorum olur. İşaretleyici sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekille ilişkilendirilmez, bu yüzden [ModernComment.shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/shape/) `None` döndürür. Bir [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sağlandığında yorum o şekle bağlanır. Koordinatlar hâlâ yorum işaretleyicisinin slayttaki konumunu tanımlar, şekil ilişkilendirmesi ise [ModernComment.shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/shape/) aracılığıyla alınabilir.

### **Modern Bir Yorumu Şekle Sabitleme**

Aşağıdaki örnek, hem slayt düzeyinde bir modern yorum hem de belirli bir AutoShape'e sabitlenmiş bir modern yorum oluşturur. Daha sonra her yorumdan ilişkili şekli okur.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Yorumları Farklı Şekil Türlerine Sabitleme**

[Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfından türetilen herhangi bir slayt nesnesi şekil bağlantısı olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/python-net/aspose.slides/connector/) ve grafik nesneleri (ör. grafikler) gibi [GraphicalObject](https://reference.aspose.com/slides/tr/python-net/aspose.slides/graphicalobject/) örnekleri bulunur.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her biriyle bir modern yorum ilişkilendirir.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Bir Yorumu Metne Sabitleme ve Durumunu Ayarlama**

[AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ile ilişkilendirilmiş bir modern yorum için, [ModernComment.text_selection_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/text_selection_start/) şeklin metin çerçevesindeki seçili metnin başlangıç konumunu, [ModernComment.text_selection_length](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/text_selection_length/) ise seçimin uzunluğunu belirler. Bu iki özellik birlikte yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[ModernComment.status](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/status/) özelliği, [ModernCommentStatus](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncommentstatus/) enum değerlerinden birisiyle okunabilir veya güncellenebilir:
- `NOT_DEFINED` — belirli bir modern yorum durumu tanımlanmamış.
- `ACTIVE` — yorum aktif.
- `RESOLVED` — yorum çözümlendi.
- `CLOSED` — yorum kapatıldı.

Aşağıdaki örnek, şekle sabitlenmiş bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözümlendi olarak işaretler, sunumu kaydeder ve dosyayı yeniden açtıktan sonra değerleri doğrular.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Mevcut Modern Yorumları İnceleme**

Mevcut bir sunumu incelemek için, yorumların hangi [ModernComment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/) örnekleri olduğunu kontrol edin, ardından [ModernComment.shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/text_selection_length/) ve [ModernComment.status](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/status/) özelliklerini inceleyin. `None` şekil, slayt düzeyinde bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) bağlantısı için, metin seçimi özellikleri şeklin metin çerçevesindeki ilişkili aralığı belirler.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Yorumları Kaldırma**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını nasıl kaldıracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Belirli Yorumları Kaldırma**

Aşağıdaki örnek, bir slayttan belirli yorumları nasıl kaldıracağınızı gösterir:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides modern yorumlar için çözümlendi durumu destekliyor mu?**

Evet. [ModernComment.status](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/status/) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncommentstatus/) değeriyle, `RESOLVED` dahil, okunabilir ve ayarlanabilir. Durum sunumda depolanır ve dosya yeniden açıldığında tekrar okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içe derinlik sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/parent_comment/)’a referans verebilir ve böylece yanıt zincirleri oluşturulur. API, belirli bir iç içe derinlik sınırı tanımlamaz.

**Bir yorum işaretleyicisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki ondalıklı koordinatlarla tanımlanır; bu da onu slayt üzerinde tam olarak konumlandırmanızı sağlar.