---
title: Gestion des objets d'encre de présentation en C++
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/cpp/manage-ink/
keywords:
- encre
- objet d'encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- exportation d'encre
- rendu d'encre
- masquer l'encre
- IInkOptions
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérer les objets d'encre PowerPoint, modifier les traces et les propriétés du pinceau, et contrôler l'apparence de l'encre lors de l'exportation en PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour C++."
---
## **Introduction**

PowerPoint propose une fonctionnalité d'encre qui vous permet de dessiner des traits libres. L'encre peut être utilisée pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

L'espace de noms [Aspose.Slides.Ink](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/) contient les classes et interfaces nécessaires pour travailler avec les objets d'encre. Par exemple, l'interface [IInk](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iink/) représente un objet d'encre sur une diapositive.

## **Différences entre les objets ordinaires et les objets d'encre**

Les objets d'une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l'objet lui‑même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l'arrière‑plan. Pour plus d'informations, consultez [Shape Layout Format](https://docs.aspose.com/slides/fr/cpp/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu PowerPoint gère un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les méthodes standard [IShape::get_Width](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_width/) et [IShape::get_Height](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'encre**

Une trace d'encre est un élément de base utilisé pour enregistrer la trajectoire d'un stylet lorsqu'un utilisateur écrit avec de l'encre numérique. Une trace stocke une séquence de points connectés.

La forme d'encodage la plus simple spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau est utilisé pour tracer des lignes qui relient les points d'une trace d'encre. Le pinceau possède sa propre couleur et taille, représentées par les méthodes [IInkBrush::get_Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iinkbrush/get_color/) et [IInkBrush::get_Size](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iinkbrush/get_size/) .

### **Définir la couleur du pinceau d'encre**

Ce code C++ montre comment définir la couleur d'un pinceau d'encre :

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Définir la taille du pinceau d'encre**

Ce code C++ montre comment définir la taille d'un pinceau d'encre :

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, de sorte que PowerPoint n'affiche pas la taille du pinceau (la section de données correspondante est grisâtre). Lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux — il suppose toujours que l'épaisseur de la ligne est nulle (voir l'image précédente).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, la taille du pinceau de ses traces doit être prise en compte. Ici, l'objet cible (la trace de texte manuscrit) a été redimensionnée à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l'apparence de l'encre lors de l'exportation et du rendu**

Aspose.Slides fournit l'interface [IInkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/) pour contrôler la manière dont les objets d'encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses méthodes pour masquer totalement l'encre ou modifier la façon dont les opérations de masque du pinceau d'encre sont interprétées.

Les options d'encre sont disponibles via les options d'exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Méthode des options d'encre |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Les deux mêmes paramètres sont disponibles via ces méthodes :

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_hideink/) détermine si les objets d'encre sont inclus dans la sortie. Sa valeur par défaut est `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) détermine si une opération de masque est interprétée comme une opacité lors du rendu d'un pinceau d'encre. Sa valeur par défaut est `true` ; réglez‑la sur `false` pour utiliser l'opération ROP à la place.

### **Masquer les objets d'encre dans la sortie PDF**

Par défaut, les objets d'encre restent visibles lors de l'exportation. Appelez [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_hideink/) avec `true` lorsque vous avez besoin d'une sortie propre sans annotations manuscrites ou autre contenu d'encre.

L'exemple C++ suivant exporte une présentation au format PDF tout en masquant tous les objets d'encre :

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Masquer les objets d'encre lors du rendu d'une diapositive en image**

Pour masquer les objets d'encre lors du rendu des diapositives en images bitmap, configurez [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) et transmettez les options de rendu à la méthode [ISlide::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/) .

L'exemple C++ suivant rend la première diapositive comme une image PNG sans objets d'encre :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Contrôler le rendu du masque d'encre**

La méthode [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d'encre. La valeur par défaut est `true`, ce qui utilise l'opacité. Appelez la méthode avec `false` pour utiliser l'opération ROP à la place.

L'exemple C++ suivant exporte une diapositive au format SVG et utilise le rendu basé sur ROP pour les opérations de masque d'encre :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

La même configuration peut être appliquée via [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) lors de l'exportation d'une présentation ou du rendu d'une diapositive au format TIFF.

### **Choisir de masquer ou de conserver l'encre**

Utilisez [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_hideink/) avec `true` lorsque le fichier exporté doit être une version propre d'une présentation annotée, par exemple, une copie finale destinée à la distribution sans marques de révision.

Laissez l'encre visible (le réglage par défaut `false`) lorsque les annotations d'encre font partie du contenu prévu, comme des commentaires de révision, des notes manuscrites, des surlignages ou des dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales séparées à partir de la même présentation sans modifier les objets d'encre sources.

## **FAQ**

**Puis‑je modifier la couleur ou la taille d'un trait d'encre existant ?**

Oui. Récupérez la trace via [IInk::get_Traces](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iink/get_traces/), puis modifiez son [IInkTrace::get_Brush](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iinktrace/get_brush/). Vous pouvez appeler [IInkBrush::set_Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iinkbrush/set_color/) et [IInkBrush::set_Size](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ink/iinkbrush/set_size/) sur le pinceau.

**Masquer l'encre modifie‑t‑il la présentation source ?**

Non. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/iinkoptions/set_hideink/) n'affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets d'encre dans la présentation source.

**Quels formats d'exportation prennent en charge les options d'encre ?**

Vous pouvez configurer les options d'encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d'exportation ou de rendu correspondantes présentées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/cpp/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, consultez [Shape Effective Properties](https://docs.aspose.com/slides/fr/cpp/shape-effective-properties/#get-effective-font-height-value).
* Pour les détails sur l'exportation PDF, voir [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/cpp/convert-powerpoint-to-pdf/).
* Pour les détails sur l'exportation HTML, voir [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/cpp/convert-powerpoint-to-html/).
* Pour les détails sur l'exportation SVG, voir [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/cpp/render-a-slide-as-an-svg-image/).
* Pour les détails sur l'exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/cpp/convert-powerpoint-to-tiff/).
* Pour les détails sur le rendu diapositive‑vers‑image, voir [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/cpp/convert-slide/).