---
title: Yorum
type: docs
weight: 230
url: /tr/python-net/examples/elements/comment/
keywords:
- yorum
- modern yorum
- yorum ekle
- yoruma eriş
- yorumu kaldır
- yoruma yanıt ver
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da slayt yorumlarını yönetin: ekleyin, okuyun, yanıt verin, düzenleyin, silin ve PowerPoint ve OpenDocument için zincirli yorumlarla çalışın."
---
Modern yorumları ekleme, okuma, kaldırma ve yanıt verme işlemlerini **Aspose.Slides for Python via .NET** kullanarak gösterir.

## **Modern Yorum Ekle**

Kullanıcı tarafından oluşturulan bir yorum yaratın ve sunumu kaydedin.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Yorum yazarını ekle.
        author = presentation.comment_authors.add_author("User", "U1")

        # Modern bir yorum ekle.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Modern Yoruma Eriş**

Varolan bir sunumdan modern bir yorumu okuyun.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # İlk modern yoruma eriş.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Modern Yorumu Kaldır**

Bir yorumu kaldırın ve güncellenmiş dosyayı kaydedin.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Yorumu kaldır.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Modern Yorum'a Yanıt Ver**

Üst modern yoruma yanıtlar ekleyin.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Üst yorum ekle.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # İlk yanıtı ekle.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # İkinci yanıtı ekle.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```