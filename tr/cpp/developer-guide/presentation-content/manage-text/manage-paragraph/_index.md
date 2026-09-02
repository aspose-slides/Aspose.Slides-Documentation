---
title: C++'ta PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- sarkıt girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'e
- paragrafı HTML'e
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) şekil içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyinde biçimlendirmeye erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) bir paragraftaki metin çalışmasını (run) temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin içerebilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm ile Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks aracılığıyla erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki adet daha [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içermesi için yeterli sayıda [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. Karakter düzeyinde biçimlendirmeyi [IPortion::get_PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_portionformat/) üzerinden uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu C++ örneği adımları uygular:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralandırma, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides'te liste ayarları [IBulletFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks aracılığıyla erişin.
3. Seçilen slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin.
5. Metin çerçevesindeki varsayılan paragrafı kaldırın.
6. Sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) oluşturun.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) değerini [BulletType::Symbol](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve madde işareti yüksekliğini ayarlayın.
9. Paragrafları metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) değerini [BulletType::Numbered](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu C++ örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görüntü kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks aracılığıyla erişin.
3. Bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin ve onun [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin.
4. Metin çerçevesindeki varsayılan paragrafı kaldırın.
5. Madde işareti görselini yükleyin ve sunumun resim koleksiyonuna [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) değerini [BulletType::Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın.
8. Görseli [ISlidesPicture::set_Image](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/set_image/) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafları metin çerçevesine ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu C++ örneği bir resim madde işareti oluşturur:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Çok Seviyeli Liste Oluşturma**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_depth/) ayarlayarak paragrafları bir listenin farklı seviyelerinde konumlandırabilirsiniz. Üst seviye derinliği `0` dır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin ve metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. Onların [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_depth/) değerlerini `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu C++ örneği dört seviyeli bir madde işaretli liste oluşturur:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

Bir numaralı paragraf için gösterilecek ilk numarayı ayarlamak amacıyla [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) kullanın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturun ve bir slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
2. Şeklin metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) değerini ilgili paragraflar için sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu C++ örneği her paragraf için özel bir başlangıç numarası atar:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Paragraf Düzeni ve Bitiş Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu yöntem yalnızca ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginleft/) kullanın. Yalnızca ilk satırı taşımak gerektiğinde ise [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) kullanın.

Aşağıdaki örnek birkaç paragraf oluşturur ve ilk satır girintisinin paragraf düzenine etkisini göstermek için farklı [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) değerleri uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve onlara farklı [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Sarkıt Girinti Ayarlama**

Sarkıt girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) ile oluşturursunuz. Girintiyi negatif bir değer olarak ayarlayarak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Pratikte, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginleft/) paragraf gövdesinin sol konumunu tanımlar ve [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) ilk satırın bu kenar boşluğuna göre konumunu belirler. Sarkıt girinti oluşturmak için pozitif bir margin-left değeri ve negatif bir girinti değeri ayarlayın.

Bu biçimlendirme, kaynakça, referans, sözlük girdileri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır; ilk satırın ilk karakteri altında değil.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her paragraf için pozitif bir [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginleft/) değeri ayarlayın.
6. Sarkıt girinti etkisini oluşturmak için negatif bir [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf için sarkıt girintinin nasıl ayarlanacağını gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafların sarkıt girintisi](hanging_indent.png)

### **Paragraf Sonu Çalışma Özelliklerini Ayarlama**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipini atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) oluşturun.
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_fontheight/) ve [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_latinfont/) ayarlayın.
6. Biçimi [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) ile atayın ve sunumu kaydedin.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Paragraf İçeriğini İçeri ve Dışarı Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphcollection/addfromhtml/) kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürün.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slayta erişin ve bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metoduna gönderin.
6. Değiştirilmiş sunumu kaydedin.

Bu C++ örneği HTML'i bir metin çerçevesine içe aktarır:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Paragraf Metnini HTML'e Dışa Aktarma**

[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphcollection/exporttohtml/) kullanarak seçili bir paragraf aralığını HTML olarak dışa aktarın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun ve istenen sunumu yükleyin.
2. Slayta erişin ve metni içeren [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) öğesini bulun.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) öğesine erişin.
4. Export etmek istediğiniz başlangıç paragrafı indeksini ve dışa aktarılacak paragraf sayısını belirterek [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metodunu çağırın.
5. Döndürülen HTML dizesini bir dosyaya yazın.

Bu C++ örneği ilk metin şekilindeki tüm paragrafları dışa aktarır:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Paragrafı Resim Olarak Render Etme**

[IParagraph::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getimage/) tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akışa [IImage::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) ile kaydedin. İçeren şekli render etmenize veya bitmap'i elle kırpmanıza gerek yoktur.

[IParagraph::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getimage/) paragraf ebeveyn koleksiyonunda bulunamazsa, geçerli render sınırları yoksa veya render edilemezse `nullptr` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanımdan sonra döndürülen görüntüyü serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte Render Etme**

sample.pptx adlı bir sunum dosyamız olduğunu ve tek bir slayta sahip olduğunu varsayalım; ilk şekil üç paragraf içeren bir metin kutusudur.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, normal bir metin şeklinin ikinci paragrafını varsayılan ölçekte render eder ve döndürülen görüntüyü PNG formatında kaydeder.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Sonuç:

![Paragraf resmi](paragraph_to_image_output.png)

#### **Paragrafı Tablo Hücresinde Ölçeklendirme ile Render Etme**

[IParagraph::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getimage/) aşırı yüklemesini kullanarak `float scaleX` ve `float scaleY` parametrelerini geçerek yatay ve dikey ölçek faktörlerini ayarlayabilirsiniz. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olacak şekilde render eder ve sonucu PNG görüntüsü olarak kaydeder.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

1 ölçek faktörü eksen boyutunu varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` kullanmak, genişliği ve yüksekliği yaklaşık iki kat olan bir görüntü üretir; bu da dört kat daha fazla piksel demektir. Daha büyük faktörler genellikle yakınlaştırma veya yüksek çözünürlüklü çıktı için daha keskin metin sağlar, ancak bellek kullanımı ve dosya boyutunu da artırır. `1`'in altındaki faktörler daha az ayrıntı ile daha küçük görüntüler üretir. En-boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

Bir şeklin tamamını [IShape::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getimage/) ile render etmek, çıktının şeklin dolgu, kenarlık veya diğer görsel bağlamını içermesi gerektiğinde faydalıdır. Sadece paragraf resmi için [IParagraph::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getimage/) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satırların metin çerçevesinin kenarlarında kesilmemesi için kaydırmayı devre dışı bırakmak üzere [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_wraptext/) kullanın.

**Belirli bir paragrafın slayttaki tam sınırlarını nasıl elde edebilirim?**

Paragrafın sınırlayıcı dikdörtgenini almak için [IParagraph::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getrect/) kullanın. Tek bir bölümün sınırlarını elde etmek için [IPortion::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/getrect/) kullanın.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yayılmış) nerede kontrol edilir?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) paragraf seviyesinde bir ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafa uygulanır.

**Paragrafın bir bölümü için düzeltme dilini ayarlayabilir miyim?**

Evet. Bireysel bölümler için [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/) kullanarak bir paragrafta birden çok dilde metin bulunabilir.