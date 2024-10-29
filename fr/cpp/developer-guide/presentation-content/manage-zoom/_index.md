---
title: Gérer le Zoom
type: docs
weight: 60
url: /fr/cpp/manage-zoom/
keywords: "Zoom, cadre de zoom, Ajouter un zoom, Formater le cadre de zoom, Résumé zoom, Présentation PowerPoint, C++, Aspose.Slides for C++"
description: "Ajoutez un zoom ou des cadres de zoom aux présentations PowerPoint en C++"
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de sauter vers et depuis des diapositives, sections et portions spécifiques d'une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s'avérer très utile.

![overview_image](Overview.png)

* Pour résumer l'ensemble d'une présentation sur une seule diapositive, utilisez un [Résumé Zoom](#Résumé-Zoom).
* Pour ne montrer que des diapositives sélectionnées, utilisez un [Zoom de Diapositive](#Zoom-de-Diapositive).
* Pour ne montrer qu'une seule section, utilisez un [Zoom de Section](#Zoom-de-Section).

## **Zoom de Diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n'importe quel ordre sans interrompre le fil de votre présentation. Les zooms de diapositive sont idéaux pour les courtes présentations sans beaucoup de sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les zooms de diapositives vous aident à explorer plusieurs morceaux d'informations tout en ayant l'impression d'être sur une seule toile.

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2), l'interface [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame), et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer des Cadres de Zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom.
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

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
autoshape->get_TextFrame()->set_Text(u"Deuxième Diapositive");

// Crée un arrière-plan pour la troisième diapositive
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crée une zone de texte pour la troisième diapositive
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Troisième Diapositive");

//Ajoute des objets ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Créer des Cadres de Zoom avec des Images Personnalisées**
Avec Aspose.Slides pour C++, vous pouvez créer un cadre de zoom avec une image de prévisualisation de diapositive différente de cette manière : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière-plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment créer un cadre de zoom avec une image différente :

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crée un arrière-plan pour la deuxième diapositive
SetSlideBackground(slide, Color::get_Cyan());

// Crée une zone de texte pour la troisième diapositive
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Deuxième Diapositive");

// Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Ajoute l'objet ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formater les Cadres de Zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom. 

Vous pouvez contrôler le formatage d'un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l'arrière-plan d'une image du deuxième objet de cadre de zoom.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment changer le formatage d'un cadre de zoom sur une diapositive : 

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
autoshape->get_TextFrame()->set_Text(u"Deuxième Diapositive");

// Crée un arrière-plan pour la troisième diapositive
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crée une zone de texte pour la troisième diapositive
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Troisième Diapositive");

//Ajoute des objets ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Définit une image personnalisée pour l'objet zoomFrame1
zoomFrame1->set_Image(image);

// Définit un format de cadre zoom pour l'objet zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Paramétrage pour ne pas montrer l'arrière-plan pour l'objet zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser des zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Ou vous pouvez les utiliser pour mettre en évidence comment certains morceaux de votre présentation se connectent. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer des Cadres de Zoom de Section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment créer un cadre de zoom sur une diapositive :

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle Section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Ajoute un objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Créer des Cadres de Zoom de Section avec des Images Personnalisées**

En utilisant Aspose.Slides pour C++, vous pouvez créer un cadre de zoom de section avec une image de prévisualisation de diapositive différente de cette manière : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment créer un cadre de zoom avec une image différente :

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle Section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Crée une nouvelle image pour l'objet zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Ajoute l'objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formater les Cadres de Zoom de Section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section. 

Vous pouvez contrôler le formatage d'un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l'objet de zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre de zoom de section créé.
9. Définissez la capacité de *retour à la diapositive d'origine depuis la section liée*. 
10. Supprimez l'arrière-plan d'une image de l'objet cadre de zoom de section.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment changer le formatage d'un cadre de zoom de section :

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Ajoute une nouvelle diapositive à la présentation
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Ajoute une nouvelle Section à la présentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Ajoute un objet SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formatage pour SectionZoomFrame
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

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Résumé Zoom**

Un résumé zoom est comme une page d'atterrissage où tous les éléments de votre présentation sont affichés en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit à un autre dans votre présentation dans l'ordre que vous souhaitez. Vous pouvez être créatif, avancer rapidement ou revisiter des éléments de votre diaporama sans interrompre le fil de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de résumé zoom, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Créer un Résumé Zoom**

Vous pouvez ajouter un cadre de résumé zoom à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de résumé zoom à la première diapositive.
4. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment créer un cadre de résumé zoom sur une diapositive :

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

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Ajouter et Supprimer une Section de Résumé Zoom**

Toutes les sections dans un cadre de résumé zoom sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). Vous pouvez ajouter ou supprimer un objet de section de résumé zoom via l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Ajoutez une nouvelle diapositive et section à la présentation.
5. Ajoutez la section créée au cadre de résumé zoom.
6. Supprimez la première section du cadre de résumé zoom.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment ajouter et supprimer des sections dans un cadre de résumé zoom :

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

//Ajoute un objet SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Ajoute une nouvelle diapositive à la présentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Ajoute une nouvelle section à la présentation
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Ajoute une section au Résumé Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Supprime une section du Résumé Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formater les Sections de Résumé Zoom**

Pour créer des objets de section de résumé zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de résumé zoom. 

Vous pouvez contrôler le formatage pour un objet de section de résumé zoom dans un cadre de résumé zoom de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Obtenez un objet de section de résumé zoom pour le premier objet de la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre de section zoom créé.
9. Définissez la capacité de *retour à la diapositive d'origine depuis la section liée*. 
11. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
12. Modifiez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment changer le formatage pour un objet de section de résumé zoom :

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

// Formatage pour l'objet SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Sauvegarde la présentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```