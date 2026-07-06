---
title: C++ Sunumlarından Metin Bölümü Sınırlarını Alın
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/cpp/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında metin bölümü sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin kesitini temsil eder ve bu kesitle çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bölümler bir metin kesitinin sınırlarını almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini elde etmek için [IPortion::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/getrect/) kullanımını gösterir. Ayrıca bir bölümün başlangıç koordinatlarını elde etmek için [IPortion::GetCoordinates](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/getcoordinates/) kullanımını gösterir. Ek olarak, tek bir metin kesitine bir köprü ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı aracılığıyla nasıl çözümlendiğini anlama ve belirtilen bir yazı tipinin bulunmadığı durumları yönetme gibi yaygın bölümle ilgili senaryoları vurgular.

## **Bir Metin Bölümünün Sınır Dikdörtgeni**

[IPortion::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/getrect/) kullanarak bir metin bölümünün sınırlayıcı dikdörtgenini alın:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Bir Metin Bölümünün Koordinatlarını Alın**

[IPortion::GetCoordinates](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/getcoordinates/) kullanarak bir metin bölümünün başlangıç koordinatlarını alın:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **SSS**

**Tek bir paragraftaki metnin yalnızca bir kısmına bir köprü uygulayabilir miyim?**

Evet, bireysel bir bölüme [bir köprü atayın](/slides/tr/cpp/manage-hyperlinks/) yapabilirsiniz; yalnızca o kesit tıklanabilir olacaktır, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan ya da metin çerçevesinden alır?**

Bölüm seviyesindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) üzerinde ayarlanmamışsa, Aspose.Slides bunu [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) veya [theme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda mevcut değilse ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/cpp/font-selection-sequence/) uygulanır. Metin yeniden akışa girebilir: ölçümler, heceleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir paragrafın geri kalanından bağımsız olarak, bölüm bazlı metin dolgusu saydamlığını veya bir degradeyi ayarlayabilir miyim?**

Evet, [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) seviyesindeki metin rengi, dolgu ve saydamlık komşu kesitlerden farklı olabilir.