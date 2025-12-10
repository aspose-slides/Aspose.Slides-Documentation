---
title: Gérer le Zoom de la présentation en C++
linktitle: Gérer le Zoom
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
description: "Créer et personnaliser le Zoom avec Aspose.Slides pour C++ — passez d’une section à l’autre, ajoutez des miniatures et des transitions dans les présentations PPT, PPTX et ODP."
---

## **Vue d'ensemble**
Les Zooms dans PowerPoint vous permettent de passer d’une diapositive, d’une section ou d’une partie spécifique d’une présentation à une autre. Lors d’une présentation, cette capacité de navigation rapide à travers le contenu peut s’avérer très utile. 

![overview_image](Overview.png)

* Pour résumer toute une présentation sur une seule diapositive, utilisez un [Summary Zoom](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour afficher uniquement une section, utilisez un [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Un slide zoom peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le flux de votre présentation. Les slide zooms sont idéaux pour les présentations courtes sans de nombreuses sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les slide zooms vous aident à approfondir plusieurs informations tout en donnant l’impression de travailler sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de slide zoom, Aspose.Slides propose l’énumération [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2), l’interface [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer des cadres de zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un cadre de zoom sur une diapositive :
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

// Ajoute de nouvelles diapositives à la présentation
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

// Ajoute des objets ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides pour C++, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette façon : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un cadre de zoom avec une image différente :
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crée un arrière-plan pour la deuxième diapositive
SetSlideBackground(slide, Color::get_Cyan());

// Crée une zone de texte pour la troisième diapositive
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crée une nouvelle image pour l'objet Zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Ajoute l'objet ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formater les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier le format d’un cadre simple. Plusieurs options de formatage sont disponibles pour un cadre de zoom. 

Vous pouvez contrôler le format d’un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives à lier auxquelles vous souhaitez connecter le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l’arrière‑plan d’une image du deuxième objet de cadre de zoom.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment modifier le format d’un cadre de zoom sur une diapositive : 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Ajoute de nouvelles diapositives à la présentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//Crée un arrière-plan pour la deuxième diapositive
SetSlideBackground(slide2, Color::get_Cyan());

//Crée une zone de texte pour la deuxième diapositive
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Crée un arrière-plan pour la troisième diapositive
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Crée une zone de texte pour la troisième diapositive
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Ajoute des objets ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//Définit une image personnalisée pour l'objet zoomFrame1
zoomFrame1->set_Image(image);

//Définit un format de cadre zoom pour l'objet zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//Paramètre pour ne pas afficher l'arrière-plan de l'objet zoomFrame2
zoomFrame2->set_ShowBackground(false);

//Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Section Zoom**

Un section zoom est un lien vers une section de votre présentation. Vous pouvez utiliser les section zooms pour revenir à des sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour montrer comment certaines parties de votre présentation sont reliées. 

![overview_image](seczoomsel.png)

Pour les objets de section zoom, Aspose.Slides propose l’interface [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer des cadres de section zoom**

Vous pouvez ajouter un cadre de section zoom à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de section zoom (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un cadre de zoom sur une diapositive :
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


### **Créer des cadres de section zoom avec des images personnalisées**

En utilisant Aspose.Slides pour C++, vous pouvez créer un cadre de section zoom avec une image d’aperçu de diapositive différente de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez un cadre de section zoom (contenant une référence à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un cadre de zoom avec une image différente :
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


### **Formater les cadres de section zoom**

Pour créer des cadres de section zoom plus compliqués, vous devez modifier le format d’un cadre simple. Plusieurs options de formatage sont disponibles pour un cadre de section zoom. 

Vous pouvez contrôler le format d’un cadre de section zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de section zoom (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de section zoom créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de section zoom créé.
9. Activez la possibilité de *revenir à la diapositive d’origine depuis la section liée*. 
10. Supprimez l’arrière‑plan d’une image de l’objet de cadre de section zoom.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment modifier le format d’un cadre de section zoom :
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

// Formatage du SectionZoomFrame
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


## **Summary Zoom**

Un summary zoom ressemble à une page d’atterrissage où toutes les parties de votre présentation sont affichées simultanément. Lors d’une présentation, vous pouvez utiliser le zoom pour passer d’un endroit à un autre dans votre présentation dans l’ordre de votre choix. Vous pouvez être créatif, sauter en avant ou revenir à des parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de summary zoom, Aspose.Slides propose les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) ainsi que certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer un Summary Zoom**

Vous pouvez ajouter un cadre de summary zoom à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de summary zoom à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un cadre de summary zoom sur une diapositive :
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


### **Ajouter et supprimer une section de Summary Zoom**

Toutes les sections d’un cadre de summary zoom sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), stockés dans l’objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). Vous pouvez ajouter ou supprimer un objet de section de summary zoom via l’interface [ISummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de summary zoom à la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de summary zoom.
6. Supprimez la première section du cadre de summary zoom.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment ajouter et supprimer des sections dans un cadre de summary zoom :
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


### **Formater les sections de Summary Zoom**

Pour créer des objets de section de summary zoom plus complexes, vous devez modifier le format d’un cadre simple. Plusieurs options de formatage sont disponibles pour un objet de section de summary zoom. 

Vous pouvez contrôler le format d’un objet de section de summary zoom dans un cadre de summary zoom de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de summary zoom à la première diapositive.
4. Récupérez un objet de section de summary zoom pour le premier objet depuis le `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de section de summary zoom créé.
9. Activez la capacité de *revenir à la diapositive d’origine depuis la section liée*. 
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment modifier le format d’un objet de section de summary zoom :
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

//Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

//Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

//Ajoute une nouvelle section à la présentation
pres->get_Sections()->AddSection(u"Section 2", slide);

//Ajoute un objet SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Obtient le premier objet SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

//Formatage du SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

//Enregistre la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis‑je contrôler le retour à la diapositive « parent » après l’affichage de la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) ou le [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) possède une méthode `set_ReturnToParent` qui renvoie le spectateur à la diapositive d’origine après avoir visité le contenu cible.

**Puis‑je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le Zoom prend en charge la définition d’une durée de transition afin que vous puissiez contrôler la longueur de l’animation de saut.

**Existe‑t‑il des limites quant au nombre d’objets Zoom qu’une présentation peut contenir ?**

Aucune limite d’API stricte n’est documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visionneur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.