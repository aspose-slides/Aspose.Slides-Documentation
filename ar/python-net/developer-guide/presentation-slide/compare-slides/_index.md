---
title: قارن الشرائح
type: docs
weight: 50
url: /python-net/compare-slides/
keywords: "قارن شرائح PowerPoint, قارن شريحتين, عرض تقديمي, بايثون, Aspose.Slides"
description: "قارن شرائح العرض التقديمي PowerPoint في بايثون"
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) وفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). ترجع هذه الطريقة القيمة true للشرائح/التخطيطات والشرائح/الشرائح الرئيسية التي تتطابق في بنيتها ومحتواها الثابت.

تكون شريحتان متساويتين إذا كانت جميع الأشكال، والأنماط، والنصوص، والحركة، وما إلى ذلك، متطابقة. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة، مثل SlideId والمحتوى الديناميكي، مثل قيمة التاريخ الحالية في عنصر النمط الخاص بالتاريخ.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("الشريحة الرئيسية في العرض 1#{0} هي مساوية للشريحة الرئيسية في العرض 2#{1}".format(i,j))
```