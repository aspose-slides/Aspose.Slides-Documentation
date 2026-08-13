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
description: "Aspose.Slides ile C++'da PowerPoint şekilleri ve metni için 3D efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for C++ şekiller ve metin için PowerPoint tarzı 3D biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, kıvrımlar, aydınlatma, malzeme, degrade veya resim dolguları ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleri hakkında. Ayrı 3D model dosyalarının eklenmesi veya düzenlenmesi hakkında değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılan 2D çıktıya renderlar.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arabiriminin [get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_threedformat/) metodunu kullanın. Metod, o şekil için 3D sahneyi kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) döndürür.

Metin için, [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) arabiriminin [get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/get_threedformat/) metodunu kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli metodlar şunlardır:

| Metod | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_camera/) | Görüş noktası, ön ayarlı kamera tipi, dönüş, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D dönüş ön ayarına uymak için. |
| [get_LightRig](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_lightrig/) | Işık ön ayarı, yön ve ışık dönüşü. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [set_Material](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_material/) | Düz, mat, plastik veya metal gibi yüzey materyali. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek için. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılmak veya yan rengini ön dolgu ile eşleştirmek için. |
| [set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekiller veya metin için derinliği, özellikle kıvrım ve material ayarlarıyla birlikte, ince ayar yapmak için. |
| [get_BevelTop](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_beveltop/) ve [get_BevelBottom](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya şekillendirilmiş bir kenar eklemek için. |
| [get_ContourColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_contourcolor/) ve [set_ContourWidth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D nesnenin etrafındaki kontur. | Renderlanmış çıktıda nesne sınırını vurgulamak için. |

## **3D Şekil Oluşturma**

Bir şeklin inandırıcı bir 3D görünüm elde etmesi için genellikle dört tür ayara ihtiyacı vardır:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın renderlanmasını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şekil kalınlığa ihtiyaç duyar.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsüne renderlar.

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

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
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

Renderlanmış slayt görüntüsü, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metin bulunan mavi 3D renderlanmış dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te 3D döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'siyle ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerleri vurgulanmış PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'de kamera tipi ve dönüş, [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) aracılığıyla ayarlanır:

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
```

Kamera, izleyicinin nesneyi algılayışını değiştirmek istediğinizde kullanılır. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides'in render sırasında kullandığı 3D bakış açısını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için [set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ve yan renk için [get_ExtrusionColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) ayarlayın:

```cpp
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

[set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_depth/) i, PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği kıvrım, malzeme ve metin efektleriyle birleştirirken kullanın. Birçok şekil senaryosunda, `set_ExtrusionHeight` daha açık bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3D Efektlerle Degrade veya Resim Dolguları Kullanma**

3D biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek şekle bir degrade dolgu ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
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

Renderlanmış çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi- turuncu degrade dolgu ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_03.png)

Bunun yerine resim dolgusu kullanmak için, görüntüyü sunuma ekleyin ve şekil dolgusuna atayın:

```cpp
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
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Resim ön yüzde renderlanırken, ekstrüzyon 3D yan yüzey olarak renderlanır:

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirme, şekil gövdesini etkiler. Metin 3D biçimlendirme, metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, desen dolgulu bir metin oluşturur, WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) üzerinde 3D ayarları yapılandırır:

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

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
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

Metin, kavisli, ekstrüze 3D harfler olarak renderlanır:

![Kavisli WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu renderlanmış 3D metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit düzen formatlarına renderlarken veya dışa aktarırken, 3D sahne rasterleştirilir veya 2D sonuç olarak çıkışa çizilir. Bu, slaytları [PNG](/slides/tr/cpp/convert-powerpoint-to-png/), [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/) veya [video conversion](/slides/tr/cpp/convert-powerpoint-to-video/) çerçeveleri oluştururken de geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, dolgu ve slayt ölçeğinin birleşimine bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özelliklerini](/slides/tr/cpp/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak saklanmak yerine renderlanır.

## **SSS**

### Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?

Aspose.Slides, şekiller ve metin için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını izleyicinin döndürebileceği etkileşimli 3D sahnelere dönüştürmez. PPTX içinde, 3D biçimlendirme, formatın desteklediği yerlerde PowerPoint'te düzenlenebilir kalır.

### 3D model ile 3D efekt arasındaki fark nedir?

3D model, bir sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir PowerPoint şekline veya metnine uygulanan, döndürme, ekstrüzyon, kıvrım, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri kapsar.

### Görünür bir 3D şekil için hangi ayarlar gereklidir?

En azından bir kamera dönüşü ve ya ekstrüzyon ya da derinlik ayarlayın. Pratikte ayrıca ışık rig'i ve malzeme ayarları da yapılmalı ki renderlanan yüzeylerde net vurgular ve gölgeler olsun.

### Hem şekillere hem de metne 3D efektler uygulayabilir miyim?

Evet. Şekil gövdesi için [IShape] ve metin için [ITextFrameFormat] kullanın.

### 3D efektler, görüntülere, PDF, HTML veya video çerçevelerine dışa aktarılırken görünecek mi?

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretirken 3D efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir 3D nesne değildir.

### Kalıtım ve tema ayarları uygulandıktan sonra son 3D değerleri okuyabilir miyim?

Evet. [Şekil Etkili Özellikleri](/slides/tr/cpp/shape-effective-properties/) içinde açıklanan etkili biçimlendirme API'lerini kullanarak son kamera, ışık rig'i, kıvrım ve ilgili 3D değerleri okuyabilirsiniz.