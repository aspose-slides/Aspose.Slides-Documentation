---
title: C++ Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Sunum
- 3D Döndürme
- 3D Derinlik
- 3D Ekstrüzyon
- 3D Degrade
- 3D Metin
- PowerPoint
- Sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++ içinde PowerPoint şekilleri ve metni için 3D efektler uygulayın ve işleyin. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for C++ şekiller ve metin için PowerPoint tarzı 3D biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma, malzeme, degrade veya resim dolguları ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="primary" %}}
Bu makale PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Bağımsız 3D model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektleri dışa aktarılan 2D çıktıya işler.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzünün [get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_threedformat/) yöntemini kullanın. Bu yöntem, o şekil için 3D sahneyi kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) döndürür.

Metin için, [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) arayüzünün [get_ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/get_threedformat/) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli yöntemler şunlardır:

| Yöntem | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_camera/) | Görüş noktası, ön ayarlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarıyla eşleştirmek. |
| [get_LightRig](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_lightrig/) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirir. |
| [set_Material](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_material/) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlar. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürür. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür kılar veya yan rengi ön dolgu ile eşleştirir. |
| [set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için derinliği ince ayarlar, özellikle kenar yumuşatma ve malzeme ayarlarıyla birlikte. |
| [get_BevelTop](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_beveltop/) ve [get_BevelBottom](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya kalıplanmış bir kenar ekler. |
| [get_ContourColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/get_contourcolor/) ve [set_ContourWidth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D nesnenin etrafındaki kontur. | İşlenmiş çıktıda nesne sınırını vurgular. |

## **3D Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3D görünmesi için genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıtıldığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak işler.

```cpp
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

İşlenmiş slayt görüntüsü dikdörtgeni kalın bir 3D blok olarak gösterir:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te 3D döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides'te, kamera tipini ve döndürmeyi [IThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) aracılığıyla ayarlayın:

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

İzleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kamerayı kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından işleme sırasında kullanılan 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Kalınlık için [set_ExtrusionHeight] ve yan renk için [get_ExtrusionColor] ayarlayın:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği kenar yumuşatma, malzeme ve metin efektleriyle birleştirmek istediğinizde [set_Depth] kullanın. Çoğu şekil senaryosunda, `set_ExtrusionHeight` daha açık bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3D Efektlerle Degrade veya Resim Dolguları Kullanma**

3D biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek şekle degrade dolgu ve yanlara daha koyu bir ekstrüzyon rengi uygular:

```cpp
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

İşlenen çıktı, ön yüze degrade uygulamayı korur ve ekstrüzyonu ayrı olarak işler:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Bunun yerine resim doldurması kullanmak için, görüntüyü sunuma ekleyin ve şekil dolgusuna atayın:

```cpp
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

Resim ön yüze işlenirken, ekstrüzyon 3D yan yüzey olarak işlenir:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirme şekil gövdesini etkiler. Metin 3D biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, desen dolgu ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) üzerinde 3D ayarları yapılandırır:

```cpp
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

Metin, eğimli, ekstrüde edilmiş 3D harfler olarak işlenir:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Dışa Aktarma ve İşleme Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit düzen formatlarına işleme veya dışa aktarma sırasında, 3D sahne rasterleştirilir veya çıktı içinde 2D bir sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/cpp/convert-powerpoint-to-png/)​'ye işlediğinizde, [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/)​'ye dışa aktardığınızda, [HTML](/slides/tr/cpp/convert-powerpoint-to-html/)​'ye dışa aktardığınızda veya [video conversion](/slides/tr/cpp/convert-powerpoint-to-video/)​ için kareler oluşturduğunuzda geçerlidir.

Şu noktalara dikkat edin:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık takımı, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Miras alınan veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/cpp/shape-effective-properties/)​'ı okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak korunmak yerine işlenir.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3D efektlerini oluşturur ve işler. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını, izleyicinin döndürebileceği etkileşimli 3D sahnelere dönüştürmez. PPTX formatında, 3D biçimlendirme, formatın desteklediği yerde PowerPoint içinde düzenlenebilir olarak kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

Bir 3D model, sunuma eklenen ayrı bir 3D nesnedir. Bir 3D efekt ise, döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma ve malzeme gibi normal bir PowerPoint şekline veya metnine uygulanan biçimlendirmedir. Bu makale 3D efektleri kapsar.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

En azından bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarlamanız gerekir. Pratikte, işlenmiş yüzeylerin net vurgular ve gölgeler elde etmesi için bir ışık takımı ve malzeme de ayarlanmalıdır.

**3D efektleri hem şekillere hem de metne uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) ve metin için [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) kullanın.

**3D efektler, görüntülere, PDF, HTML veya video karelerine dışa aktarılırken görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktı, HTML çıktı ve video dönüşümü için kareler üretirken 3D efektleri işler. Dışa aktarılan çıktı, işlenmiş görünümü içerir; düzenlenebilir bir 3D nesne içermez.

**Miras ve tema ayarları uygulandıktan sonra son 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık takımı, kenar yumuşatma ve ilgili 3D değerlerini okumak için [Shape Effective Properties](/slides/tr/cpp/shape-effective-properties/)​ içinde açıklanan etkili biçimlendirme API'lerini kullanın.