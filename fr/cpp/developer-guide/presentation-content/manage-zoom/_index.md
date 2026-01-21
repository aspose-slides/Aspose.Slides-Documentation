---
title: Gérer le zoom de présentation en C++
linktitle: Gérer le zoom
type: docs
weight: 60
url: /fr/cpp/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de résumé
- ajouter un zoom
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et personnaliser le Zoom avec Aspose.Slides pour C++ — passez d’une section à l’autre, ajoutez des miniatures et des transitions pour les présentations PPT, PPTX et ODP."
---

## **Aperçu**
Les Zoom dans PowerPoint vous permettent de sauter vers et depuis des diapositives, des sections et des parties spécifiques d’une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s’avérer très utile. 

![overview_image](Overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Summary Zoom](#Summary-Zoom).
* Pour n’afficher que les diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour n’afficher qu’une seule section, utilisez un [Section Zoom](#Section-Zoom).

## **Zoom de Diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n’importe quel ordre que vous choisissez sans interrompre le flux de votre présentation. Les zooms de diapositive sont excellents pour les présentations courtes sans de nombreuses sections, mais vous pouvez toujours les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à explorer plusieurs informations tout en donnant l’impression d’être sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/), l’interface [IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) ainsi que certaines méthodes sous l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Créer des cadres de zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez de nouvelles diapositives auxquelles vous avez l’intention de lier les cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment créer un cadre de zoom sur une diapositive : 
``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute de nouvelles diapositives à la présentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crée un arrière-plan pour la deuxième diapositive
SetSlideBackground(slide2, Color::get_Cyan());

// Crée une zone de texte pour la deuxième diapositive
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crée un arrière-plan pour la troisième diapositive
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crée une zone de texte pour la troisième diapositive
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Ajoute des objets ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides pour C++, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette façon : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez une nouvelle diapositive à laquelle vous avez l’intention de lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière-plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment créer un cadre de zoom avec une image différente : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds a new slide to the presentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide, Color::get_Cyan());

// Creates a text box for the third slide
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a new image for the zoom object
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Adds the ZoomFrame object
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formater les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le format d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom. 

Vous pouvez contrôler le format d’un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez de nouvelles diapositives à lier auxquelles vous avez l’intention de lier le cadre de zoom. 
3. Ajoutez du texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
8. Supprimez l’arrière-plan d’une image du deuxième objet cadre de zoom.
5. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment changer le format d’un cadre de zoom sur une diapositive : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Ajoute de nouvelles diapositives à la présentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Crée un arrière-plan pour la deuxième diapositive
SetSlideBackground(slide2, Color::get_Cyan());

// Crée une zone de texte pour la deuxième diapositive
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crée un arrière-plan pour la troisième diapositive
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crée une zone de texte pour la troisième diapositive
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Ajoute des objets ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Définit une image personnalisée pour l'objet zoomFrame1
zoomFrame1->set_Image(image);

// Définit le format du cadre zoom pour l'objet zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Paramètre pour ne pas afficher l'arrière-plan pour l'objet zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour souligner comment certaines parties de votre présentation sont liées. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l’interface [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) et certaines méthodes sous l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Créer des cadres de zoom de section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous avez l’intention de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment créer un cadre de zoom sur une diapositive : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Ajoute un objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Créer des cadres de zoom de section avec des images personnalisées**

En utilisant Aspose.Slides pour C++, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous avez l’intention de lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment créer un cadre de zoom avec une image différente : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Ajoute un objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formater les cadres de zoom de section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier le format d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section. 

Vous pouvez contrôler le format d’un cadre de zoom de section sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous avez l’intention de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet cadre de zoom de section créé.
9. Définissez la capacité de *retourner à la diapositive d’origine depuis la section liée*.
10. Supprimez l’arrière-plan d’une image du cadre de zoom de section.
11. Modifiez le format de ligne du deuxième cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment changer le format d’un cadre de zoom de section : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Ajoute un objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Mise en forme du SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom de Résumé**

Un zoom de résumé ressemble à une page d’atterrissage où toutes les pièces de votre présentation sont affichées en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d’un endroit de votre présentation à un autre dans n’importe quel ordre. Vous pouvez faire preuve de créativité, avancer rapidement ou revisiter des parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de résumé, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/), et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) ainsi que certaines méthodes sous l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Créer un zoom de résumé**

Vous pouvez ajouter un cadre de zoom de résumé à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec arrière-plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de résumé à la première diapositive.
4. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment créer un cadre de zoom de résumé sur une diapositive : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 2", slide);

// Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 3", slide);

// Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 4", slide);

// Ajoute un objet SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Ajouter et supprimer une section de zoom de résumé**

Toutes les sections d’un cadre de zoom de résumé sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/), qui sont stockés dans l’objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/). Vous pouvez ajouter ou supprimer un objet de section de zoom de résumé via l’interface [ISummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec arrière-plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé dans la première diapositive.
4. Ajoutez une nouvelle diapositive et une section à la présentation.
5. Ajoutez la section créée au cadre de zoom de résumé.
6. Supprimez la première section du cadre de zoom de résumé.
7. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment ajouter et supprimer des sections dans un cadre de zoom de résumé : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

//Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 2", slide);

// Ajoute un objet SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Ajoute une nouvelle section à la présentation
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Ajoute une section au Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Supprime la section du Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formater les sections du zoom de résumé**

Pour créer des objets de section de zoom de résumé plus compliqués, vous devez modifier le format d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de zoom de résumé. 

Vous pouvez contrôler le format d’un objet de section de zoom de résumé dans un cadre de zoom de résumé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec arrière-plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Obtenez un objet de section de zoom de résumé pour le premier objet à partir de la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) en ajoutant une image à la collection images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet cadre de zoom de section créé.
9. Définissez la capacité de *retourner à la diapositive d’origine depuis la section liée*. 
11. Modifiez le format de ligne du deuxième cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ vous montre comment changer le format d’un objet de section de zoom de résumé : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

//Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 2", slide);

// Ajoute un objet SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Obtient le premier objet SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Mise en forme de l'objet SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après avoir affiché la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) ou la [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) possède une méthode `set_ReturnToParent` qui renvoie les spectateurs à la diapositive d’origine après avoir consulté le contenu cible.

**Puis-je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le zoom permet de définir une durée de transition afin que vous puissiez contrôler la durée de l’animation de saut.

**Existe-t-il des limites au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’y a pas de limite stricte documentée dans l’API. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.