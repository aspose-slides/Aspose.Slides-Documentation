---
title: C++ Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özellik
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak net kod örnekleriyle PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi öğrenin; bu, slayt tasarımı ve otomasyonunu hızlandırır."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzenle oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for C++ ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Alma**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/get_allnodes/ ) üzerinde yineleme yapın, ardından [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartshape/get_textframe/ ) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/ ) öğesini okuyun.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **SmartArt Nesnesinin Düzen Türünü Değiştirme**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartlayouttype/ ) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartnode/get_ishidden/ ) düğümün SmartArt veri modelinde gizli olup olmadığını belirtir. Seçilen düzen, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartlayouttype/ ) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/ ) ve [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/ ) alt düğümlerin bir üst düğüm altında nasıl düzenlendiğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/organizationchartlayouttype/ ) değerine bağlı olarak alt düğümleri soldan, sağdan veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/organizationchartlayouttype/ ) `LeftHanging` değerine ayarlar.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Resimli Organizasyon Şeması Oluşturma**

Resimli organizasyon şeması, görüntü tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartlayouttype/ ) `PictureOrganizationChart` değerini kullanın.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya ters çevirme destekliyor mu?**

Evet. Seçilen SmartArt düzeni ters çevirmeyi desteklediğinde, [SmartArt::set_IsReversed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/set_isreversed/ ) yöntemi diyagram yönünü soldan sağa’dan sağa sola'ya değiştirir ya da tersine çevirir.

**SmartArt'ı aynı slayta veya başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalayabilirim?**

SmartArt şekli [clone'lamak](/slides/tr/cpp/shape-manipulations/) için [ShapeCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapecollection/addclone/ ) kullanabilir veya SmartArt içeren tüm slaytı [clone'lamak](/slides/tr/cpp/clone-slides/) için aynı yöntemi kullanabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için bir raster görüntüye nasıl render edebilirim?**

[Render the slide](/slides/tr/cpp/convert-powerpoint-to-png/) ya da tüm sunumu PNG veya JPEG formatına render edin. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi olduğunda belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [Shape::set_AlternativeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/set_alternativetext/ ) veya [Shape::set_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/set_name/ ) değeri atayın, bu değeri [BaseSlide::get_Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseslide/get_shapes/ ) içinde arayın ve eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/ismartart/ ) olduğunu kontrol edin.