---
title: C++'ta Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/cpp/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PowerPoint şekilleri ve metni için 3B efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for C++ şekiller ve metinler için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, döndürme, ekstrüzyon, eğimler, aydınlatma, malzeme, degrade veya resim doldurmalar ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme hakkında değildir. Bir slaytı bir görüntüye, PDF'e veya HTML'e dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya işler.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) yöntemini kullanın. Yöntem, bu şeklin 3B sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli yöntemler şunlardır:

| Yöntem | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Bakış noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirmek. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki ışık vurgularının ve gölgelerin nasıl göründüğünü değiştirmek. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometriyi daha düz, daha yumuşak, parlak veya metalik göstermek. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli görülebilir kalın bir 3B nesne haline getirmek. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Ekstrüde edilmiş yanların rengi. | Derinliği görünür kılmak veya yan rengini ön doldurma ile eşleştirmek. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekiller veya metin için derinliği ince ayarlamak, özellikle eğim ve malzeme ayarlarıyla birlikte. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya şekillendirilmiş bir kenar eklemek. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3B nesnenin etrafındaki kontur. | İşlenmiş çıktıda nesne sınırını vurgulamak. |

## **3B Şekil Oluşturma**

Bir şeklin inandırıcı bir şekilde 3B görünmesi için genellikle dört tür ayara ihtiyacı vardır:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işleneceğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derecede, ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutlarının iki katı bir PNG görüntüsü olarak işler ve sunumu PPTX olarak kaydeder.

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

İşlenmiş slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metin olan işlenmiş mavi 3B dikdörtgen](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-B Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-B Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te, kameraya [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) üzerinden erişin. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünümü seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

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

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides'in render etme sırasında kullandığı 3B bakış noktasını değiştirir.

### **Şablon Şekilden Kamera Yönelimini Kopyalama**

Bir şablon şeklinin kamera yönelimini eşleştirmek için, ön ayarını [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) ile okuyun ve [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) ile uygulayın. Örnek, `template.pptx` dosyasını açar ve ilk slaydın ilk şekline ait kamera yönelimini ikinci şekle kopyalar. Her iki şeklin de zaten 3B aydınlatması vardır ve ikinci şeklin açık bir kamera döndürmesi yoktur.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) derece cinsinden açıları döndürür. `0` dizini enlem, `1` dizini boylam ve `2` dizini devrimdir. Açılar bu sırayla [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) metoduna gönderilir. Kaynağın açık bir döndürmesi yoksa, `GetRotation` null işaretçi döndürür, bu yüzden ikinci şeklin açıları ayarlanmamış bırakılır. `(0, 0, 0)` gibi açık bir döndürme üç sıfır içeren bir dizi döndürür ve kopyalanmalıdır.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`camera-copy.pptx` dosyasını PowerPoint'te yeniden açtığınızda, sağdaki ok, soldaki dikdörtgenle aynı kamera ön ayarı ve döndürmeye sahiptir. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğini kullanır.

![Üstten ve sağdan bakıldığında aynı kamera yönelimine sahip mavi bir 3B dikdörtgen ve sağ yön ok](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te, derinlik kontrolü bu görünen kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) , yan renk için ise [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) ayarlayın. Bu örnek, bir dikdörtgene 100 puanlık ekstrüzyon ve mor yanlar verir, ayrıca kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

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

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) metodu bir 3B şeklin derinliğini ayarlar. [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) metodu ekstrüzyon efektinin yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurma uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu bir renk uygular. Degrade, 0 ve 100 konumlarında başlangıç ve bitişi işaretler. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutlarının iki katı bir PNG görüntüsü olarak işlenir:

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

İşlenmiş çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak işler:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_03.png)

Resim doldurma kullanmak için, görüntüyü sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı mevcut bir dosya gerektirir. Resmi dikdörtgeni dolduracak şekilde genişletir, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece cinsinden ayarlar. Şekli dosya kaydetmeden veya render etmeden bellekte yapılandırır:

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

Resim ön yüzde işlenirken, ekstrüzyon 3B yan yüzey olarak işlenir:

![Ön yüzde fotoğraf doldurma ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, turuncu‑beyaz ızgara deseniyle metin oluşturur, yukarı doğru bir yay uygular ve 3B ayarları [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinliği puan cinsindendir, ışık döndürmesi derecedir. Şekil doldurma ve kontur gizlenir, böylece yalnızca metin görünür. Örnek, varsayılan slayt boyutlarının iki katı bir PNG görüntüsü oluşturur ve sunumu PPTX olarak kaydeder:

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

Metin, eğimli, ekstrüzyonlu 3B harfler olarak işlenir:

![Eğimli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu işlenmiş 3B metin](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

Bir şeklin 3B görünümünü korurken metnin okunabilir kalmasını sağlamak için [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) metodunu [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) üzerinden çağırın. Değer `true` ise metin 3B sahneden dışarıdadır. Değer `false` ise metin sahneye katılır ve 3B yönelimini izler.

Bu ayar, şeklin 3B biçimlendirmesini kaldırmaz: kamera, aydınlatma, malzeme ve ekstrüzyon, [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) aracılığıyla yapılandırılmış olarak kalır. Ayrıca normal döndürmeden farklıdır. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) slayt düzleminde şekli döndürürken, [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) metnin sınırlayıcı kutusu içinde özel döndürmesini kontrol eder. Metni 3B sahneden dışarıda tutmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve orijinalin yanına kopyalar. Her iki şeklin de aynı 3B biçimlendirmesi vardır; yalnızca metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutların iki katı bir PNG olarak render eder.

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

Sol tarafta, metin 3B yönelimi izler. Sağ tarafta, düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünen ekstrüzyon ve 3B yönelimi korur.

![Yan yana 3B dikdörtgenler: KeepTextFlat solda false, sağda true](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına render ederken veya dışa aktarırken, 3B sahne 2B sonuç olarak rasterleştirilir veya çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/cpp/convert-powerpoint-to-png/), [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/) formatlarına render ederken veya [video conversion](/slides/tr/cpp/convert-powerpoint-to-video/) için çerçeveler oluştururken geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Miras alınmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/cpp/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine render edilir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metinler için PowerPoint 3B efektlerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını, izleyicinin döndürebileceği etkileşimli 3B sahnelere dönüştürmez. PPTX formatında, 3B biçimlendirme, formatın desteklediği yerlerde PowerPoint'te düzenlenebilir olarak kalır.

**Bir 3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, eğim, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri kapsar.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En azından bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarlanmalıdır. Pratikte, render edilen yüzlerin net vurgular ve gölgeler elde etmesi için ışık rig'i ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) , metin için ise [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) kullanın.

**3B efektler, görüntülere, PDF'e, HTML'e veya video çerçevelerine dışa aktarıldığında görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretirken 3B efektleri render eder. Dışa aktarılan çıktı, render edilmiş görünümü içerir; düzenlenebilir bir 3B nesne değildir.

**Miras ve tema ayarları uygulandıktan sonra son 3B değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık rig'i, eğim ve ilgili 3B değerlerini okumak için [Shape Effective Properties](/slides/tr/cpp/shape-effective-properties/) sayfasında açıklanan etkili biçimlendirme API'lerini kullanın.