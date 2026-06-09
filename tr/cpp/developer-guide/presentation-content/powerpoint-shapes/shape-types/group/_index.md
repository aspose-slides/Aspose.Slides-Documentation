---
title: C++'ta Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/cpp/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında şekilleri gruplamayı ve gruptan çıkarmayı öğrenin — hızlı, adım adım rehber ve ücretsiz C++ kodu."
---
## **Genel Bakış**

Bu makale Aspose.Slides'da grup şekilleriyle nasıl çalışılacağını açıklar. Bir grup şeklinin slayta nasıl ekleneceğini, içinde şekillerin nasıl yerleştirileceğini ve güncellenmiş sunumun nasıl kaydedileceğini gösterir. Ayrıca bir grup içinde depolanan şekillere nasıl erişileceğini ve bunların `AlternativeText` değerlerinin nasıl okunacağını gösterir. Ek olarak, makale iç içe gruplar, z‑sırası ve kilitleme seçenekleri gibi ilgili grup‑şekil yeteneklerine kısaca değinir.

## **Grup Şekli Ekle**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for C++ grup şekilleri eklemeyi veya erişmeyi destekler. Eklenen bir grup şekline şekiller ekleyerek onu doldurmak veya grup şeklinin herhangi bir özelliğine erişmek mümkündür. Aspose.Slides for C++ kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını İndeksini kullanarak edinin.
1. Slayta bir grup şekli ekleyin.
1. Eklenen grup şekline şekilleri ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **AltText Özelliğine Erişim**
Bu konu, slaytlarda grup şekli ekleme ve grup şekillerinin AltText özelliğine erişme adımlarını, kod örnekleriyle birlikte gösterir. Aspose.Slides for C++ kullanarak bir slayttaki grup şeklinin AltText'ine erişmek için:

1. `Presentation` sınıfının bir örneğini oluşturun; bu sınıf bir PPTX dosyasını temsil eder.
1. Bir slaydın referansını İndeksini kullanarak edinin.
1. Slaytların şekil koleksiyonuna erişin.
1. Grup şekline erişin.
1. AltText özelliğine erişin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **SSS**

**İç içe gruplaşma (bir grup içinde grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/groupshape/) sınıfının bir [get_ParentGroup](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_parentgroup/) yöntemi vardır; bu doğrudan hiyerarşi desteğini gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grup’un slayttaki diğer nesnelere göre z‑sırasını nasıl kontrol edebilirim?**

Grup şeklinin z‑sırasını görüntü yığındaki konumunu incelemek için [GroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/groupshape/)’nin [Z-Order position](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_zorderposition/) yöntemini kullanın.

**Taşıma/düzenleme/grup çözmeyi önleyebilir miyim?**

Evet. Grubun kilitleme bölümü, nesne üzerindeki işlemleri kısıtlamanıza olanak sağlayan [get_GroupShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/groupshape/get_groupshapelock/) yöntemi aracılığıyla ortaya çıkar.