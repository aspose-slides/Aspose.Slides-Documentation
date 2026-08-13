---
title: C++ Sunumlarından Şekil Etkin Özelliklerini Al
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/cpp/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık seti
- köşe şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'nin, kesin PowerPoint render'ı için etkin şekil özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir; örneğin:

1. Bir slayttaki bölüm (portion) özellikleri.  
1. Bir düzen veya ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir stil içerdiğinde.  
1. Sunumdaki global metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides son “görüntülendiği gibi” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkin** değerleri döndürür. Bunları yerel format nesnesinde `GetEffective` metodunu çağırarak alabilirsiniz.

Aşağıdaki örnek, etkin değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu, bir metin çerçevesi ve en az bir bölüm içerdiğini varsayar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan geçerli biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformateffectivedata/) gibi bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtılan biçimlendirme değiştirildikten sonra `GetEffective` metodunu tekrar çağırmak, önbellekteki verileri yenileyebilir ve daha önce alınan nesne artık önceki durumu temsil etmeyebilir. Etkin değerleri daha sonra yeniden kullanmak üzere korumanız gerekiyorsa, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera'nın Etkin Özelliklerini Al**

Aspose.Slides bir kameranın etkin özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icameraeffectivedata/) arayüzü, etkin kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, kamera için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Işık Seti'nin Etkin Özelliklerini Al**

Aspose.Slides bir ışık setinin etkin özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrigeffectivedata/) arayüzü, etkin ışık seti özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, ışık seti için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Köşe Şeklinin Etkin Özelliklerini Al**

Aspose.Slides bir şekil köşesinin (bevel) etkin özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) arayüzü, bir şeklin yüzey-yüzey özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, bir şeklin üst köşesi için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Metin Çerçevesinin Etkin Özelliklerini Al**

Aspose.Slides kullanarak bir metin çerçevesinin etkin özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformateffectivedata/) arayüzü, etkin metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Metin Stilinin Etkin Özelliklerini Al**

Aspose.Slides kullanarak bir metin stilinin etkin özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextstyleeffectivedata/) arayüzü, etkin metin stil özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin stil özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Etkin Yazı Tipi Yüksekliği Değerini Al**

Aspose.Slides kullanarak etkin yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün yerel yazı tipi yüksekliği değerleri farklı sunum yapısı seviyelerinde ayarlandığında, bölümün etkin yazı tipi yüksekliğinin nasıl değiştiğini gösterir.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tablo İçin Etkin Dolgu Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için etkin dolgu biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/) arayüzü, etkin dolgu biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi ise sütun biçimlendirmesinden, sütun biçimlendirmesi de tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkin dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) olduğunu varsayar.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **SSS**

### `GetEffective` bir anlık görüntü (snapshot) döndürür mü?

Her zaman değildir. Etkin veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Bir sonraki `GetEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellekteki verileri yenileyebilir; bu nedenle daha önce elde edilen nesne kalıcı bir anlık görüntü olarak kabul edilmemelidir.

### Etkin özellikleri ne zaman tekrar okumalıyım?

Yerel biçimlendirme, üst stil, düzen biçimlendirme, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `GetEffective` metodunu tekrar çağırın. Sonraki çağrı, biçimlendirme hiyerarşisini yeniden değerlendirir ve geçerli etkin sonucu döndürür.

### Bir düzen/ana slayt değiştirildiğinde veya kaldırıldığında, zaten alınmış etkin özellikler etkilenir mi?

Evet, ancak değişiklik bir sonraki `GetEffective` çağrısında yansır. Bir üst biçimlendirme kaynağı değiştirildiyse veya kaldırıldıysa, daha önce alınan etkin veri eski hale gelebilir. `GetEffective` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve sonuçta yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

### Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?

Hayır. Etkin veri nesneleri yalnızca hesaplanmış değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri yeniden elde edin.

### Bir özellik şekil seviyesinde, düzen/ana slaytta ve global ayarlarda hiç ayarlanmamışsa ne olur?

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Çözülmüş değer, geçerli etkin verinin bir parçası haline gelir.

### Etkin bir yazı tipi değerinden, boyutu veya yazı tipini hangi seviyenin sağladığını anlayabilir miyim?

Doğrudan değil. Etkin veri nihai değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum düzeyindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın nerede ortaya çıktığını görebilirsiniz.

### Neden bazı zamanlarda etkin değerler yerel değerlerle aynı görünüyor?

Çünkü yerel değer son değer olarak kalmıştır (daha üst seviyeden bir kalıtım gerekmemiştir). Bu durumlarda etkin değer yerel değerle aynı olur.

### Etkin özellikleri ne zaman, yerel özellikleri ne zaman kullanmalıyım?

Tüm kalıtım uygulandıktan sonra “görüntülendiği gibi” sonucu elde etmeniz gerektiğinde etkin veriyi kullanın; örneğin renkleri, girintileri veya boyutları hizalamak için. Bu değerleri ilerideki biçimlendirme değişikliklerinden bağımsız olarak saklamanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmek istiyorsanız, yerel özellikleri düzenleyin ve gerektiğinde sonuçları doğrulamak için etkin veriyi tekrar okuyun.