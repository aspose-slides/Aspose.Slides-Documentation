---
title: Rendu des diapositives de présentation au format SVG en C++
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- options d'export SVG
- SVG interactif
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Exportez les diapositives PowerPoint au format SVG en C++ et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image évolutif basé sur XML qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides for C++ exporte chaque diapositive dans un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible entre les navigateurs ou prêt pour une utilisation interactive.

## **Exporter une diapositive en SVG**

Créez une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L'exemple suivant exporte chaque diapositive d'une présentation sous forme de fichier SVG distinct.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Le nom de fichier utilise [ISlide::get_SlideNumber](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/get_slidenumber/) plutôt que l'index de boucle. Vous pouvez également exporter une forme individuelle avec [IShape::WriteAsSvg](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/writeassvg/) lorsqu'une visionneuse de diapositives ou une page Web n'a besoin que de cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_useframesize/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_useframerotation/) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) sur `true` lorsque le texte doit être rendu sans ligatures.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Contrôler le texte et les polices**

### **Vectoriser tout le texte**

Réglez [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus cohérent entre les navigateurs, mais le texte n'est plus sélectionnable ni consultable en tant que texte SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Choisir la façon dont les polices externes sont gérées**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées de façon externe. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de polices séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre le texte qui utilise des polices externes uniquement sous forme de graphiques. Vérifiez les licences des polices avant d'embarquer des polices.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Réduire la taille des images intégrées**

Utilisez [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_picturescompression/) pour réduire la résolution des images intégrées, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) pour omettre les zones recadrées d'origine, et [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_jpegquality/) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au prix d'une perte de fidélité d’image ou de données d’image retenues.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Attribuer des ID stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgshapeformattingcontroller/) pour définir [ISvgShape::set_Id](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgshape/set_id/) pour chaque forme SVG. Pour définir également des valeurs [ISvgTSpan::set_Id](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgtspan/set_id/) sur les éléments texte `tspan`, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assignez l’un ou l’autre contrôleur avec [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Le contrôleur suivant utilise [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_officeinteropshapeid/), qui est stable pendant la durée de vie de la forme, ainsi qu’un compteur réutilisable pour ses spans de texte. Cela rend les ID générés adaptés au post‑traitement d’une présentation inchangée.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Ajouter des gestionnaires d'événements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgshapeformattingcontroller/), appelez [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isvgshape/seteventhandler/) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgevent/) pour ajouter un gestionnaire d'événement JavaScript à une forme exportée. Assignez le contrôleur avec [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

La page hôte peut définir la fonction JavaScript référencée par le gestionnaire. L’attribution d’ID et de gestionnaires d’événements permet aux visionneuses de diapositives, aux améliorations d’accessibilité et à d’autres flux de travail SVG interactifs.

## **FAQ**

**Quand faut‑il utiliser [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) au lieu de [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de rendre un SVG plus petit?**

Commencez par compresser les images intégrées, supprimer les zones d’image recadrées et choisir des fichiers de polices liés lorsque l’environnement cible peut les fournir. Testez le résultat car une résolution d’image plus basse, une qualité JPEG réduite et du texte vectorisé entraînent tous des compromis différents entre qualité et taille.

**Puis‑je modifier les éléments SVG exportés après l’exportation?**

Oui. Assignez des ID via un contrôleur de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou script de navigateur.