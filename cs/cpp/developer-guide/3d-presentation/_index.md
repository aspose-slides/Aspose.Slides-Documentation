---
title: Vytvoření 3D efektů v prezentacích pomocí C++
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Použijte a renderujte 3D efekty pro tvary a text v PowerPointu v C++ s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro C++ může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty jako otáčení, extruzi, fazety, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="primary" %}}
Tento článek se zabývá 3D efekty formátování na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides vykresluje tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Pomocí rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) použijte metodu [get_ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_threedformat/) k aplikaci 3D formátování na tvar. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/) a jeho metodu [get_ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/get_threedformat/). Tím se 3D formátování použije na textový rámec místo těla tvaru.

Nejdůležitější metody jsou:

| Metoda | Co řídí | Kdy použít |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_camera/) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídání přednastavenému 3D otáčení v PowerPointu. |
| [get_LightRig](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_lightrig/) | Přednastavené světlo, směr a rotace světla. | Změňte, jak se na 3D povrchu zobrazují světla a stíny. |
| [set_Material](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_material/) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plochěji, jemněji, leskle nebo kovově. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Jak daleko se tvar rozšiřuje dozadu od své přední strany. | Převést plochý tvar na viditelně silný 3D objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s výplní přední strany. |
| [set_Depth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_depth/) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Doladit hloubku pro tvary nebo text, zejména v kombinaci s nastavením fazet a materiálu. |
| [get_BevelTop](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_beveltop/) a [get_BevelBottom](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Vyvýšené nebo zaoblené hrany na přední a zadní straně. | Přidejte zjemněný nebo formovaný okraj místo ostré ploché strany. |
| [get_ContourColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_contourcolor/) a [set_ContourWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Obrys kolem 3D objektu. | Zdůrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvořit 3D tvar**

- Nastavení kamery, protože výchozí pohled zepředu může skrýt extruzi.
- Nastavení světla, protože osvětlení činí tvary a strany čitelnými.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený snímek ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otočit tvar pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v podokně 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení nastavenému přes API kamery.

![Panel 3‑D otáčení v PowerPointu se zvýrazněnými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení pomocí [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D pohled, který používá PowerPoint i Aspose.Slides při renderování.

## **Přidat extruzi a hloubku**

Extruze způsobí, že tvar vypadá tlustě tím, že se rozšíří za přední stranu. V PowerPointu ovládání hloubky nastavuje tuto viditelnou tloušťku a ovládání barvy určuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu přiřazené k barvám extruze a vlastnostem výšky extruze](img_02_02.png)

Nastavte [set_ExtrusionHeight](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_extrusionheight/) pro tloušťku a [get_ExtrusionColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) pro barvu stran:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Použijte [set_Depth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_depth/), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku s fazetami, materiálem a textovými efekty. V mnoha scénářích tvaru je `set_ExtrusionHeight` přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použít gradientové nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále použít stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad použije gradientovou výplň na tvar a tmavší barvu extruze na strany:

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

![Vykreslený 3D obdélník s modro‑oranžovým gradientem výplně a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru:

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

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použít 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, použije WordArt transformaci a nakonfiguruje 3D nastavení na [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/):

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

![Vykreslený 3D text s zakřiveným WordArt transformem, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/cpp/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/cpp/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného zařízení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo na motivu založené hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/cpp/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, kde formát podporuje editaci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, fazeta, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou potřeba pro viditelný 3D tvar?**

Minimálně nastavte otáčení kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelné zařízení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) pro tělo tvaru a [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při vytváření obrázků snímků, PDF výstupu, HTML výstupu a snímků použité pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a motivu?**

Ano. Použijte API efektivního formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/cpp/shape-effective-properties/), abyste získali koneční hodnoty kamery, světelného zařízení, fazety a souvisejících 3D parametrů.