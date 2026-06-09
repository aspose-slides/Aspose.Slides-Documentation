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
description: "Aspose.Slides for C++'nin, kesin PowerPoint renderlaması için şekil etkin özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme düzeyinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm özellikleri.
1. Layout veya ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir stil içeriyorsa.
1. Sunumdaki global metin ayarları.

Yerel değerler herhangi bir düzeyde tanımlanabilir veya atlanabilir. Aspose.Slides nihai “render edilmiş” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkin** değerleri döndürür. Bunları, yerel format nesnesi üzerinde `GetEffective` metodunu çağırarak alabilirsiniz.

Aşağıdaki örnek etkin değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi ile en az bir bölüm içerdiğini varsayar.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformateffectivedata/) gibi bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Ebeveyn veya kalıtılan biçimlendirme değiştirildikten sonra `GetEffective` tekrar çağrılması önbellek verisini yenileyebilir ve daha önce elde edilen nesne artık önceki durumu temsil etmeyebilir. Daha sonraki kullanım için etkin değerleri korumanız gerekiyorsa, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera'nın Etkin Özelliklerini Al**

Aspose.Slides bir kameranın etkin özelliklerini almanıza izin verir. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icameraeffectivedata/) arayüzü, etkin kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/), [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, kameranın etkin özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
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

## **Light Rig'in Etkin Özelliklerini Al**

Aspose.Slides bir ışık setinin (light rig) etkin özelliklerini almanıza izin verir. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrigeffectivedata/) arayüzü, etkin ışık seti özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/), [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, ışık setinin etkin özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
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

## **Şekil Eğriliğinin (Bevel) Etkin Özelliklerini Al**

Aspose.Slides bir şekil eğriliğinin (bevel) etkin özelliklerini almanıza izin verir. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) arayüzü, bir şekil için etkin yüz çıkıntısı özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/), [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, bir şeklin üst eğriliğinin (top bevel) etkin özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```cpp
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

Aspose.Slides ile bir metin çerçevesinin etkin özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformateffectivedata/) arayüzü, etkin metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```cpp
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

## **Metin Stili (Text Style) Etkin Özelliklerini Al**

Aspose.Slides ile bir metin stilinin etkin özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextstyleeffectivedata/) arayüzü, etkin metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```cpp
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

Aspose.Slides ile etkin yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün yerel yazı tipi yüksekliği değerleri farklı sunum yapısı seviyelerinde ayarlandığında etkin yazı tipi yüksekliğinin nasıl değiştiğini gösterir.

```cpp
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

Aspose.Slides ile farklı tablo parçaları için etkin dolgu biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/) arayüzü, etkin dolgu biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi ise sütun biçimlendirmesinden, sütun biçimlendirmesi ise tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo parçaları için etkin dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) olduğunu varsayar.

```cpp
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

**`GetEffective` bir anlık görüntü (snapshot) döndürür mü?**

Her zaman değildir. Etkin veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Ardından yapılan bir `GetEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellek verisini yenileyebilir; bu nedenle daha önce elde edilen nesne kalıcı bir anlık görüntü olarak ele alınmamalıdır.

**Etkin özellikleri ne zaman tekrar okumalıyım?**

Yerel biçimlendirme, ebeveyn stiller, layout biçimlendirmesi, master biçimlendirmesi veya sunum seviyesindeki varsayılanlar değiştirildikten sonra `GetEffective` tekrar çağrılmalıdır. Bir sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve geçerli etkin sonucu döndürür.

**Bir layout/master slaytı değiştirmek/kaldırmak, zaten alınmış etkin özellikleri etkiler mi?**

Evet, değişiklik bir sonraki `GetEffective` çağrısında yansıtılır. Bir ebeveyn biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen etkin veriler eski olabilir. `GetEffective` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve sonuçta fontlar, renkler, boyutlar veya diğer değerler değişebilir.

**Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Etkin veri nesneleri yalnızca hesaplanan değerleri gösterir. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri tekrar alın.

**Bir özellik şekil seviyesinde, layout/master’da ya da global ayarlarda hiç tanımlı değilse ne olur?**

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Çözülen bu değer, geçerli etkin verinin bir parçası haline gelir.

**Etkin bir yazı tipi değerinden, hangi seviyenin boyutu ya da yazı tipini sağladığını anlayabilir miyim?**

Doğrudan değil. Etkin veri yalnızca son değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve layout, master ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edip ilk açık tanımlamanın nerede olduğunu inceleyin.

**Neden etkin değerler bazen yerel değerlerle aynı görünüyor?**

Çünkü yerel değer nihai değer olmuş (daha yüksek seviyeden bir kalıtım gerekmemiş) ve bu durumda etkin değer yerel değerle aynı olur.

**Etkin özellikleri ne zaman, yerel özelliklerle ne zaman kullanmalıyım?**

Tüm kalıtım uygulandıktan sonra “render edilmiş” sonucu elde etmeniz gerektiğinde (renkleri hizalamak, girintileri veya boyutları belirlemek gibi) etkin veriyi kullanın. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak saklamanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değişikliği yapacaksanız, yerel özellikleri değiştirin ve ardından gerektiğinde etkin veriyi tekrar okuyarak sonucu doğrulayın.