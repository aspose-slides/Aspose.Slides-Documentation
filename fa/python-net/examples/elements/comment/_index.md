---
title: نظر
type: docs
weight: 230
url: /fa/python-net/examples/elements/comment/
keywords:
- کامنت
- کامنت مدرن
- افزودن کامنت
- دسترسی به کامنت
- حذف کامنت
- پاسخ به کامنت
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت نظرات اسلاید در Python با Aspose.Slides: افزودن، خواندن، پاسخ، ویرایش، حذف و کار با نظرات زنجیره‌ای برای PowerPoint و OpenDocument."
---
نمایش افزودن، خواندن، حذف و پاسخ‌دادن به نظرات مدرن با استفاده از **Aspose.Slides for Python via .NET**.

## **افزودن یک نظر مدرن**

یک نظر ایجاد کنید که توسط کاربر نویسنده شده و ارائه را ذخیره کنید.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # یک نویسندهٔ کامنت اضافه کنید.
        author = presentation.comment_authors.add_author("User", "U1")

        # یک کامنت مدرن اضافه کنید.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک نظر مدرن**

یک نظر مدرن را از یک ارائه موجود بخوانید.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # دسترسی به اولین کامنت مدرن.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **حذف یک نظر مدرن**

یک نظر را حذف کنید و فایل به‌روز شده را ذخیره کنید.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # حذف کامنت.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **پاسخ به یک نظر مدرن**

پاسخ‌ها را به یک نظر مدرن والد اضافه کنید.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # افزودن کامنت والد.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # افزودن اولین پاسخ.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # افزودن دومین پاسخ.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```