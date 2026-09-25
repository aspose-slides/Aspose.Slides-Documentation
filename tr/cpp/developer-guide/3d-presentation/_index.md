---
title: C++ Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D döndürme
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PowerPoint şekilleri ve metni için 3D efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for C++ şekiller ve metin için PowerPoint tarzı 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, kavisler, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Not" %}}
Bu makale PowerPoint şekilleri ve metin üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı 3B model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_threedformat/) yöntemini kullanın. Bu yöntem, şeklin 3B sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/get_threedformat/) yöntemini kullanın. Bu yöntem, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli yöntemler şunlardır:

| Yöntem | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_camera/) | Görüş noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya bir PowerPoint 3B döndürme ön ayarına uyum sağlamak için. |
| [get_LightRig](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_lightrig/) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [set_Material](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_material/) | Yüzey malzemesi, örneğin düz, mat, plastik veya metal. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Şeklin ön yüzünden geriye doğru ne kadar uzandığını. | Düz bir şekli belirgin kalın bir 3B nesneye dönüştürmek için. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Ekstrüde edilmiş yanların rengi. | Derinliği görünür kılmak veya yan rengini ön doldurmayla eşleştirmek için. |
| [set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekil veya metin için derinliği ince ayarlamak, özellikle kavis ve malzeme ayarlarıyla birlikte. |
| [get_BevelTop](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_beveltop/) ve [get_BevelBottom](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek için. |
| [get_ContourColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_contourcolor/) ve [set_ContourWidth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3B nesnenin etrafındaki kontur. | Renderlanan çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlanacağını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutlarının iki katı bir PNG görüntüsü olarak renderlar ve sunumu PPTX olarak kaydeder:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Renderlanan slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metinli mavi renderlanmış 3B dikdörtgen](img_01_01.png)

## **Kamerayla Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te, kameraya [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_camera/) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünümü seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);

presentation->Dispose();
```

Kamera, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanılır. Slayttaki 2B şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides render ederken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlığı ayarlamak için [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ve yan renk için [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) kullanılır. Bu örnek, dikdörtgene 100 puanlık bir ekstrüzyon ve mor yanlar verir, kamerayı döndürerek kalınlığını gösterir. Şekli dosya kaydetmeden bellekte yapılandırır:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_depth/) yöntemi bir 3B şeklin derinliğini ayarlar. [set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) yöntemi ise ekstrüzyon etkisinin yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu bir renk uygular. Degrade durakları 0 ve 100, başlangıç ve bitiş noktalarını işaret eder. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutlarının iki katı bir PNG görüntüsü olarak renderlanır:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Renderlanmış 3B dikdörtgen, mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonla:

![Mavi‑turuncu degrade doldurması ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_03.png)

Resim doldurması kullanmak için, resmi sunuma ekleyip şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olduğunu varsayar. Resmi dikdörtgeni dolduracak şekilde uzatır, 150 puanlık bir ekstrüzyon uygular ve kamera döndürmesini derecelerle ayarlar. Şekli dosya kaydetmeden veya renderlamadan bellekte yapılandırır:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Ön yüzünde fotoğraf doldurması ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen:

![Ön yüzünde fotoğraf doldurması ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için yararlıdır.

Aşağıdaki örnek, turuncu‑beyaz ızgara desenli bir metin oluşturur, yukarı doğru bir yay uygular ve 3B ayarları [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/get_threedformat/) üzerinden yapılandırır. Ekstrüzyon yüksekliği ve derinliği puan cinsindendir, ışık döndürmesi derecedir. Şekil doldurma ve kontur gizlenir, yalnızca metin görünür. Örnek, varsayılan slayt boyutunun iki katı bir PNG görüntüsü olarak renderlanır ve sunumu PPTX olarak kaydeder:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Renderlanmış 3B metin, yukarı kıvrımlı WordArt dönüşümü, turuncu desen doldurması ve koyu ekstrüzyonla:

![Yukarı kıvrımlı WordArt dönüşümü, turuncu desen doldurması ve koyu ekstrüzyonlu renderlanmış 3B metin](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

Metni okunabilir tutarken şeklin 3B görünümünü korumak için [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_keeptextflat/) metodunu, [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_textframeformat/) üzerinden çağırın. Değer `true` olduğunda metin 3B sahnenin dışında kalır. Değer `false` olduğunda metin sahneye katılır ve 3B yönelimini izler.

Bu ayar, şeklin 3B biçimlendirmesini (kamera, ışık, malzeme, ekstrüzyon) [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_threedformat/) üzerinden yapılandırılmış şekilde kaldırmaz. Aynı zamanda normal döndürmeden farklıdır. [IShape::set_Rotation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_rotation/) şekli slayt düzleminde döndürürken, [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_rotationangle/) metnin sınırlama kutusu içinde özel döndürmesini kontrol eder. Metni 3B sahneden çıkarmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli bir mavi dikdörtgen oluşturur ve orijinalin yanına kopyasını ekler. Her iki şeklin de aynı 3B biçimlendirmesi vardır; yalnızca metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki katı boyutta PNG olarak renderlar:

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

Solda, metin 3B yönelimi izler. Sağda, düz kalır ve daha okunabilir. Her iki dikdörtgen de aynı görünen ekstrüzyonu ve 3B yönelimini korur.

![Yan yana 3B dikdörtgenler: KeepTextFlat solda false, sağda true](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzenli formatlara renderlarken veya dışa aktarırken, 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/cpp/convert-powerpoint-to-png/), [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/) olarak renderladığınızda veya [video conversion](/slides/tr/cpp/convert-powerpoint-to-video/) için çerçeveler oluşturduğunuzda geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık kafesi, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/cpp/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak saklanmak yerine renderlanır.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX'te, format destekliyorsa 3B biçimlendirme PowerPoint içinde düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, kavis, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gerekir?**

En az bir kamera döndürmesi ve ekstrüzyon veya derinlik ayarı gerekir. Pratikte, renderlanan yüzeylerin net vurgular ve gölgeler alması için bir ışık kafesi ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_threedformat/), metin için [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/get_threedformat/) kullanın.

**3B efektler, görüntülere, PDF'ye, HTML'ye veya video çerçevelerine dışa aktarıldığında ortaya çıkar mı?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretildiğinde 3B efektleri renderlar. Dışa aktarılan çıktı renderlanan görünümü içerir, düzenlenebilir bir 3B nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3B değerleri okuyabilir miyim?**

Evet. Nihai kamera, ışık kafesi, kavis ve ilgili 3B değerlerini okumak için [Shape Effective Properties](/slides/tr/cpp/shape-effective-properties/) API'lerini kullanın.