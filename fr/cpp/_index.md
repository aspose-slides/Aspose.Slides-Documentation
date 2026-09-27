---
title: Aspose.Slides pour C++
second_title: Aspose.Slides pour C++
type: docs
weight: 30
url: /fr/cpp/
keywords:
- documentation
- traitement de présentation
- conversion de présentation
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides pour C++, créez une première présentation, et retrouvez les guides pour les tâches courantes, la référence API et le support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ est une bibliothèque C++ native permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument, sans Microsoft PowerPoint ni automatisation Office.

Elle charge et enregistre les fichiers PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Démarrer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/cpp/installation/">Installation</a></li>
<li><a href="/slides/fr/cpp/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/cpp/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/cpp/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/cpp/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/cpp/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construire avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/cpp/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/cpp/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/cpp/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/cpp/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/cpp/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL</p>
<ul>
<li><a href="/slides/fr/cpp/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/cpp/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/cpp/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/cpp/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/cpp/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/cpp/examples/">Exemples par élément de diapositive</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Exemples sur GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/cpp/known-issues/">Problèmes connus</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Service d'assistance payant</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

Sur Windows, créez un projet **Console App** C++ dans Visual Studio et installez le package NuGet dans la console du gestionnaire de packages (**Outils** > **Gestionnaire de packages NuGet** > **Console du gestionnaire de packages**) :

```powershell
Install-Package Aspose.Slides.Cpp
```

Sur Linux, téléchargez le package ZIP Linux et configurez le projet CMake décrit dans [Installation](/slides/fr/cpp/installation/#linux).

Ensuite, utilisez ce code comme fichier source principal de votre programme. Il crée une présentation avec une zone de texte et l'enregistre :

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Pour l'exécuter sous Windows, sélectionnez la plateforme **x64** dans la barre d'outils et appuyez sur **Ctrl+F5**. Sous Linux, enregistrez‑le sous *main.cpp* dans le dossier du projet, puis compilez‑le et exécutez‑le là‑bas :

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Le programme enregistre *hello.pptx* avec une diapositive contenant une zone de texte. Sans licence, le fichier enregistré porte un filigrane d'évaluation — voir [Licence](/slides/fr/cpp/licensing/). Pour d'autres méthodes de création et de remplissage d'une présentation, consultez [Créer des présentations](/slides/fr/cpp/create-presentation/).