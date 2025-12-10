---
title: "Gérer les paragraphes de texte PowerPoint en C++"
linktitle: "Gérer le paragraphe"
type: docs
weight: 40
url: /fr/cpp/manage-paragraph/
keywords:
- "ajouter du texte"
- "ajouter un paragraphe"
- "gérer le texte"
- "gérer le paragraphe"
- "gérer les puces"
- "retrait de paragraphe"
- "retrait suspendu"
- "puce de paragraphe"
- "liste numérotée"
- "liste à puces"
- "propriétés du paragraphe"
- "importer HTML"
- "texte vers HTML"
- "paragraphe vers HTML"
- "paragraphe vers image"
- "texte vers image"
- "exporter le paragraphe"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "C++"
- "Aspose.Slides"
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour C++ — optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP en C++."
---

Aspose.Slides fournit toutes les interfaces et classes dont vous avez besoin pour travailler avec les textes, paragraphes et portions PowerPoint en C++.

* Aspose.Slides fournit l’interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) pour vous permettre d’ajouter des objets qui représentent un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé via un retour chariot).
* Aspose.Slides fournit l’interface [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) pour vous permettre d’ajouter des objets qui représentent des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d’objets iPortions).
* Aspose.Slides fournit l’interface [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) pour vous permettre d’ajouter des objets qui représentent des textes et leurs propriétés de mise en forme. 

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de mise en forme grâce à ses objets sous‑jacent `IPortion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son index.
3. Ajoutez un rectangle [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Récupérez le ITextFrame associé au [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) et ajoutez‑les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez les fonctionnalités de mise en forme souhaitées à chaque portion en utilisant les propriétés de mise en forme exposées par l’objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code C++ implémente les étapes pour ajouter des paragraphes contenant des portions : 
```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Ajouter un TextFrame au rectangle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accéder au premier paragraphe
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Ajouter un second paragraphe
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Ajouter un troisième paragraphe
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Définissez le `Type` de la puce du paragraphe sur `Symbol` et indiquez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l’`Indent` du paragraphe pour la puce.
10. Attribuez une couleur à la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code C++ montre comment ajouter une puce de paragraphe : 
```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Ajouter un TextFrame au rectangle
ashp->AddTextFrame(u"");

// Accéder au cadre de texte
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Créer l'objet Paragraph pour le cadre de texte
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Définir le texte
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Définir le retrait de la puce
paragraph->get_ParagraphFormat()->set_Indent (25);

// Définir la couleur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// Définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Définir la hauteur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Ajouter le paragraphe au cadre de texte
txtFrame->get_Paragraphs()->Add(paragraph);

// Créer le deuxième paragraphe
// Créer l'objet Paragraph pour le cadre de texte
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Définir le texte
paragraph2->set_Text(u"This is numbered bullet");

// Définir le type et le style de la puce du paragraphe
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Définir le retrait de la puce
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Définir la couleur de la puce
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// Définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Définir la hauteur de la puce
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Ajouter le paragraphe au cadre de texte
txtFrame->get_Paragraphs()->Add(paragraph2);


// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Gérer les puces d’image**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes avec images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Chargez l’image dans [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) et indiquez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez l’`Indent` du paragraphe pour la puce.
11. Attribuez une couleur à la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter et gérer des puces d’image : 
```c++
// Crée une instance de la classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accède à la première diapositive
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Crée l'image pour les puces
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Ajoute et accède à l'AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au TextFrame de l'AutoShape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Supprime le paragraphe par défaut
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Crée un nouveau paragraphe
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Définit le style de puce du paragraphe et l'image
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Définit la hauteur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Ajoute le paragraphe au TextFrame
paragraphs->Add(paragraph);

// Enregistre la présentation au format PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Enregistre la présentation au format PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Gérer les puces multiniveaux**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter et gérer des puces multiniveaux : 
```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Ajoute et accède à l'AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre texte de l'AutoShape créé
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Efface le paragraphe par défaut
text->get_Paragraphs()->Clear();

// Ajoute le premier paragraphe
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de la puce
para1Format->set_Depth(0);

// Ajoute le deuxième paragraphe
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de la puce
para2Format->set_Depth(1);

// Ajoute le troisième paragraphe
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de la puce
para3Format->set_Depth(2);

// Ajoute le quatrième paragraphe
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de la puce
para4Format->set_Depth(3);

// Ajoute les paragraphes à la collection
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Enregistre la présentation au format PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Gérer un paragraphe avec une liste numérotée personnalisée**

L’interface [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) et d’autres qui permettent de gérer des paragraphes avec une numérotation ou une mise en forme personnalisée. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter et gérer des paragraphes avec une numérotation ou une mise en forme personnalisée : 
```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre texte de l'autoforme créé
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Supprime le paragraphe par défaut existant
textFrame->get_Paragraphs()->RemoveAt(0);

// Première liste
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Définir l’indent du paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accédez à la diapositive concernée par son index.
1. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) contenant trois paragraphes au rectangle autoshape.
1. Masquez les contours du rectangle.
1. Définissez l’indent de chaque [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) via sa propriété `BulletOffset`.
1. Enregistrez la présentation modifiée au format PPT.

Ce code C++ montre comment définir l’indent d’un paragraphe : 
```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Ajouter un TextFrame au rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Ajouter le premier paragraphe
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Ajouter le premier paragraphe
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// Ajouter au cadre texte
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Définir un retrait suspendu pour un paragraphe**

Ce code C++ montre comment définir le retrait suspendu pour un paragraphe :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Gérer les propriétés de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Récupérez la référence de la diapositive contenant le paragraphe par sa position.
1. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) contenant deux paragraphes au rectangle.
1. Définissez le `FontHeight` et le type de police des paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint : 
```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Ajouter un TextFrame au rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Ajouter le premier paragraphe
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Ajouter le deuxième paragraphe
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Importer du texte HTML dans des paragraphes**

Aspose.Slides offre un support amélioré pour l’importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez au `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code C++ implémente les étapes d’importation de textes HTML dans des paragraphes : 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Réinitialiser la couleur de remplissage par défaut
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Ajouter un TextFrame au rectangle
ashp->AddTextFrame(u" ");

// Accéder au cadre texte
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Obtenir la collection de paragraphes
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Effacer tous les paragraphes du cadre texte ajouté
ParaCollection->Clear();

// Charger le fichier HTML à l'aide d'un lecteur de flux
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Ajouter le texte du lecteur de flux HTML au cadre texte
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Créer l'objet Paragraph pour le cadre texte
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Créer l'objet Portion pour le paragraphe
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Obtenir le format de la portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Définir la police pour la portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Définir la propriété Gras de la police
pf->set_FontBold(NullableBool::True);

// Définir la propriété Italique de la police
pf->set_FontItalic(NullableBool::True);

// Définir la propriété Souligné de la police
pf->set_FontUnderline(TextUnderlineType::Single);

// Définir la taille de la police
pf->set_FontHeight(25);

// Définir la couleur de la police
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Exporter le texte d’un paragraphe vers HTML**

Aspose.Slides offre un support amélioré pour l’exportation de textes (contenus dans les paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la diapositive concernée par son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez à la [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ à StreamWriter et exportez les paragraphes souhaités.

Ce code C++ montre comment exporter les textes de paragraphes PowerPoint vers HTML : 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Accéder à la première diapositive par défaut de la présentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Index souhaité
int index = 0;

// Accéder à la forme ajoutée
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extraire le premier paragraphe en HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Écrire les données des paragraphes en HTML en indiquant l'index de départ du paragraphe, le nombre total de paragraphes à copier
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```


## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples démontrant comment enregistrer un paragraphe texte, représenté par l’interface [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/), sous forme d’image. Les deux exemples comprennent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `GetImage` de l’interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), le calcul des limites du paragraphe au sein de la forme, puis son exportation en tant qu’image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte de présentations PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis nous calculons les limites du deuxième paragraphe dans le cadre texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique comme image séparée tout en préservant les dimensions exactes et la mise en forme du texte.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

 // Enregistrer la forme en mémoire sous forme de bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

 // Créer un bitmap de forme à partir de la mémoire.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

 // Calculer les limites du deuxième paragraphe.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

 // Calculer la taille de l'image de sortie (taille minimale - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

 // Préparer un bitmap pour le paragraphe.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

 // Redessiner le paragraphe du bitmap de forme vers le bitmap du paragraphe.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée comme image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie de résolution supérieure lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des supports imprimés de haute qualité.
```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Enregistrer la forme en mémoire sous forme de bitmap avec mise à l'échelle.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Créer un bitmap de forme à partir de la mémoire.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculer les limites du deuxième paragraphe.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculer la taille de l'image de sortie (taille minimale - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Préparer un bitmap pour le paragraphe.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redessiner le paragraphe du bitmap de forme vers le bitmap du paragraphe.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Utilisez la méthode de retour à la ligne du cadre de texte ([set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)) pour désactiver le retour à la ligne afin que les lignes ne se interrompent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une portion unique) pour connaître sa position et sa taille précises sur la diapositive.

**Où se contrôle l’alignement du paragraphe (gauche/droite/centré/justifié) ?**

[Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/); il s’applique à l’ensemble du paragraphe quel que soit le format des portions individuelles.

**Puis‑je définir une langue de vérification orthographique pour une partie seulement d’un paragraphe (par ex., un mot) ?**

Oui. La langue se définit au niveau de la portion via ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)), ce qui permet à plusieurs langues de coexister dans un même paragraphe.