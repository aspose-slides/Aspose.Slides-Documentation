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
- yoruma eriş
- yorumu düzenle
- yorum yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumlarla ilgili ana tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint’te yaygın inceleme ve iş birliği senaryolarını kapsar; yazarların yorumlara atanması, yorum metni ve meta verilerin okunması, yanıt zincirlerinin oluşturulması ve seçili yorumların ya da tüm yorumların kaldırılması gibi.

PowerPoint’te yorumlar, slaytlarda ek açıklama olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Sunum açıldığında yorumların gösterilmesini veya gizlenmesini, yorumların kendisini değiştirmeden talep etmek için, bakınız [Sunum Açılırken Yorumları Gösterme veya Gizleme](/slides/tr/python-net/presentation-view-properties/).

## **Neden Sunumlara Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve meslektaşlarla iş birliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Python via .NET, yorumlarla çalışmak için aşağıdaki API’leri sunar:

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) sınıfı, tek bir yazarla ilişkili yorumları temsil eder.
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) sınıfı, bir yorumun yazar, oluşturulma zamanı, konum ve metin gibi bilgilerini sunar.
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) sınıfı, bir yazarın adı, baş harfleri ve ilişkili yorumları hakkında bilgi verir.

## **Slayt Yorumları Ekle**

Örnek iki slayt oluşturur ve bir yorum yazarını [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) ile kaydeder. Her slayta bir yorum yerleştirmek için [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) kullanır, ardından o yazar için ilk slaydın yorumlarını [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) ile alır. Konsol, ilk yorumun metnini iki kez gösterir; bu, slayt ve yazar üzerinden erişimin demonstrasyonudur ve kaydedilen sunum her iki yorumu da içerir.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Yorum Yazarını Bulma veya Oluşturma**

Aynı sunumu tekrarlı otomatik incelemelerle işlediğinizde, bir yazar eklemeden önce [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) koleksiyonunu arayın. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) hem adı hem de baş harfleri eşleştirir ve eşleşen yazarları içeren bir dizi döndürür; eşleşme yoksa boş dizi döner. Buna karşılık, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) yalnızca ada göre arama yapar, baş harfleri dikkate almaz. Koleksiyonda zaten bulunan bir adı ve baş harfleriyle [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) çağırmak bir istisna fırlatır.

Örnek, en az bir slaytı olan bir sunum dosyası gerektirir. İki geçişte de ilk eşleşen yazar yeniden kullanılır; sonuç boşsa yeni bir yazar oluşturulur. Birden çok eşleşme varsa, diğer yazarları birleştirmeden veya kaldırmadan yalnızca ilk dizi öğesi seçilir. Ardından seçilen yazar için [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) çağrılır ve sunum kaydedilir. İkinci geçiş, birinci geçişin çıktısını açar ve işlemi tekrarlar.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

İkinci geçiş, başka bir yazar eklemeden veya mevcut yorumları kaldırmadan yeni bir yorum ekler. Son dosya, `review_pass_2.pptx`, yeni yorumları orijinal yorumlarla birlikte içerir. Bir yazarın yeniden kullanılması yorumları tekilleştirmez: aynı yorumu tekrar eklemeyi önlemek için eklemeden önce ayrı bir çoğaltma algılama mekanizması uygulamanız gerekir.

## **Slayt Yorumlarına Erişim**

Örnek mevcut bir sunumu açar ve onun [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) koleksiyonunu okur. Her yazar için [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) üzerinden döner ve slayt numarasını, yorum metnini, yazar adını ve oluşturulma zamanını yazdırır. Girdi sunumunda yorumlar bulunmalı ki konsol çıktısı üretilebilsin.

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

Bir üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) sınıfının [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) özelliği, bir yorumun ebeveynini almanıza veya ayarlamanıza izin verir.

Örnek iki yazar tarafından oluşturulan yorumlar ekler ve [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) kullanarak yanıtları, bir yanıtın başka bir yanıtına yanıt vermeyi de içerecek şekilde oluşturur. [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) metoduna `None` geçirilmesi, tüm yazarların yorumlarını getirir; konsol, her girişi yanıt hiyerarşisindeki derinliğine göre girintiler. Örnek tam tartışmayı kaydeder, ilk kök yorum üzerinde [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) metodunu çağırır ve bu yorum ve yanıtları kaldırılmış ikinci bir sunum kaydeder.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) yöntemi [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) sınıfından bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) özelliği dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekle**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir AutoShape içindeki metin aralığına ilişkilendirilebilir. [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) yöntemi, slayt ve yorum işaretleyici koordinatlarının yanı sıra bir [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) argümanı da kabul eder.

`None` şekil argümanı verildiğinde yorum, slayt‑seviyesinde bir yorum olur. İşaretleyici, sağlanan koordinatlarla konumlandırılır ancak belirli bir şekle bağlanmaz; bu nedenle [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) `None` döner. Bir [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sağlandığında yorum o şekle bağlanır. Koordinatlar hâlâ slayt üzerindeki işaretleyici konumunu tanımlar, şekil ilişkilendirmesi ise [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) üzerinden alınabilir.

### **Modern Yorumları Bir Şekle Sabitleme**

Örnek, [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) iki kez çağırır: bir kez `None` şekil ile slayt‑seviyesi yorum, bir kez de dikdörtgen şeklinde bağlama. [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) okunması, slayt‑seviyesi yorumun null kontrolü için `True` ve bağlanmış yorum için `Revenue title` çıktısını verir. Her iki yorum da sunum ile kaydedilir.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Yorumları Farklı Şekil Türlerine Sabitleme**

[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) türevi herhangi bir slayt nesnesi şekil demeti olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) ve grafik nesneleri gibi [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) örnekleri bulunur.

Örnek, beş şekil türüne – bir AutoShape, bir resim çerçevesi, bir grup, bir bağlayıcı ve bir grafik – her biri için bir modern yorum ilişkilendirmek üzere [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) kullanır. Resim gömülü görüntü verisi ile sağlanır; dışa bağımlı bir görüntü gerekmez. Her yorumun kendi işaretleyici konumu vardır ve kaydedilen sunum tüm beş şekil ilişkilendirmesini korur.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Yorumları Metne Sabitle ve Durumunu Ayarla**

Bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ile ilişkili modern yorum için [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) şeklin metin çerçevesindeki seçili metnin başlangıç konumunu, [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) ise seçimin uzunluğunu belirtir. Bu iki özellik, yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) özelliği, [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) enum değerlerinden biriyle okunabilir veya güncellenebilir:

- `NOT_DEFINED` — belirli bir modern yorum durumu tanımlanmamıştır.
- `ACTIVE` — yorum aktiftir.
- `RESOLVED` — yorum çözülmüştür.
- `CLOSED` — yorum kapatılmıştır.

Örnek, bir dikdörtgenin metnindeki “quarterly revenue” ifadesine modern bir yorum bağlar. Metinden sıfır‑tabanlı [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) değerini hesaplar ve [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) değerini seçili karakter sayısına ayarlar. [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) `RESOLVED` olarak ayarlandıktan sonra sunum kaydedilir ve yeniden açılır. Dört konsol kontrolü her biri `True` yazdırmalı, şekil bağlaması, metin aralığı ve durumun korunduğunu göstermelidir.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

Örnek, modern yorumlar içeren mevcut bir sunum gerektirir ve yorumların metnini, durumunu ve bağlama ayrıntılarını yazdırır. İncelemek için, önce hangi yorumların [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) örneği olduğunu kontrol edin, ardından [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) ve [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) özelliklerine bakın. `None` şekil, slayt‑seviyesi bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) bağlaması için metin‑seçim özellikleri, şeklin metin çerçevesindeki ilgili aralığı tanımlar.

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

Aspose.Slides for Python via .NET, bir sunumdan tüm yorumları ve yazarlarını kaldırmanıza veya seçili yorumları silip geri kalanını tutmanıza olanak tanır. Aşağıdaki örnekler her iki yaklaşımı gösterir ve güncellenmiş sunumu kaydeder.

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Örnek mevcut bir sunumu açar ve her yazar için [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) metodunu çağırır, ardından yazarları kendilerini kaldırmak için [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) metodunu çalıştırır. Kaydedilen sunum ne yorum ne de yorum yazarları içerir. Yorumları gözlemlemek için yorumlar içeren bir sunum kullanın.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Belirli Yorumları Kaldırma**

Örnek bir slaytta iki yorum oluşturur ve [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) ile her yazarın yorumlarını bulur. “comment 1” metnine eşit olan yorumları toplar, ardından [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) metodunu çağırır; bu sayede seçim sırasında koleksiyon değişmez. Kaydedilen sunum sadece “comment 2” yorumunu tutar.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş bir durumu destekliyor mu?**

Evet. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) bir [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) değeriyle okunabilir ve ayarlanabilir; `RESOLVED` da dahil. Durum sunumda saklanır ve dosya yeniden açıldığında tekrar okunabilir.

**İç içe yanıt zincirleri (threaded discussions) destekleniyor mu, bir derinlik sınırı var mı?**

Evet. Her yorum, kendi [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) özelliğiyle başka bir yoruma referans verebilir; bu sayede yanıt zincirleri oluşturulur. API, belirli bir iç içe derinlik sınırı tanımlamaz.

**Bir slaytta yorum işaretleyicisinin konumu hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta (float) değerlerle tanımlanır; böylece işaretleyiciyi slayt üzerinde hassas bir şekilde yerleştirebilirsiniz.