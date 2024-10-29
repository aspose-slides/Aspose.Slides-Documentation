---
title: مقارنة الشرائح
type: docs
weight: 50
url: /ar/cpp/compare-slides/
---

## **مقارنة شريحتين**
تم إضافة طريقة Equals إلى واجهة IBaseSlide و فئة BaseSlide. وهي تُرجع قيمة true للشرائح / الشرائح التخطيطية / الشرائح الرئيسية التي تتطابق في هيكلها ومحتواها الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الرسوم المتحركة والإعدادات الأخرى، إلخ. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة، مثل SlideId والمحتوى الديناميكي، مثل قيمة التاريخ الحالي في عنصر نائب التاريخ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}