---
title: Gérer les Paragraphes PowerPoint en C++
type: docs
weight: 40
url: /cpp/manage-paragraph/
keywords: "Ajouter un paragraphe PowerPoint, Gérer les paragraphes, Indentation des paragraphes, Propriétés des paragraphes, Texte HTML, Exporter le texte des paragraphes, Présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Créer et gérer des Paragraphes, du texte, de l'indentation et des propriétés dans des présentations PowerPoint en C++"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions PowerPoint en C++.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) pour vous permettre d'ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets représentant des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) pour vous permettre d'ajouter des objets représentant des textes et leurs propriétés de formatage.

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage à travers ses objets sous-jacents `IPortion`.

## **Ajouter Plusieurs Paragraphes Contenant Plusieurs Portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes, chacun contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une forme rectangulaire [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé à l'[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` de l'[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez vos fonctionnalités de formatage préférées à chaque portion en utilisant les propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code C++ est une implémentation des étapes pour ajouter des paragraphes contenant des portions :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accédez à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoutez une AutoShape de type rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Ajoutez TextFrame au rectangle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accès au premier paragraphe
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Ajout du deuxième paragraphe
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Ajout du troisième paragraphe
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

// Enregistrez le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Gérer les Puces de Paragraphes**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Définissez le `Type` de puce pour le paragraphe à `Symbol` et définissez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l'`Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus donné aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code C++ vous montre comment ajouter une puce de paragraphe :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accédez à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoutez une AutoShape de type rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Ajoutez TextFrame au rectangle
ashp->AddTextFrame(u"");

// Accédez au cadre de texte
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Créez l'objet Paragraph pour le cadre de texte
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Définir le texte
paragraph->set_Text(u"Bienvenue dans Aspose.Slides");

// Définir l'indentation de la puce
paragraph->get_ParagraphFormat()->set_Indent (25);

// Définir la couleur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// définir IsBulletHardColor sur vrai pour utiliser sa propre couleur de puce
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Définir la hauteur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Ajouter le paragraphe au cadre de texte
txtFrame->get_Paragraphs()->Add(paragraph);

// Création du deuxième paragraphe
// Créez l'objet Paragraph pour le cadre de texte
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Définir le texte
paragraph2->set_Text(u"Ceci est une puce numérotée");

// Définir le type et le style de la puce de paragraphe
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Définir l'indentation de la puce
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Définir la couleur de la puce
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// définir IsBulletHardColor sur vrai pour utiliser sa propre couleur de puce
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Définir la hauteur de la puce
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Ajouter le paragraphe au cadre de texte
txtFrame->get_Paragraphs()->Add(paragraph2);


// Enregistrez le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Gérer les Puces d'Image**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes d'images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Image](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez l'`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus en fonction des étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment ajouter et gérer des puces d'image :

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accède à la première diapositive
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancie l'image pour les puces
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Ajoute et accède à l'Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au texte du cadre d'autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Supprime le paragraphe par défaut
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Crée un nouveau paragraphe
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Bienvenue dans Aspose.Slides");

// Définit le style et l'image de la puce de paragraphe
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Définit la hauteur de la puce
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Ajoute le paragraphe au cadre de texte
paragraphs->Add(paragraph);

// Écrit la présentation au format PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Écrit la présentation au format PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Gérer les Puces Multiniveaux**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment ajouter et gérer des puces multiniveaux :

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Ajoute et accède à l'Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre texte de l'autoshape créé
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Efface le paragraphe par défaut
text->get_Paragraphs()->Clear();

// Ajoute le premier paragraphe
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Contenu");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de puce
para1Format->set_Depth(0);

// Ajoute le deuxième paragraphe
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Niveau Deux");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de puce
para2Format->set_Depth(1);

// Ajoute le troisième paragraphe
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Niveau Trois");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de puce
para3Format->set_Depth(2);

// Ajoute le quatrième paragraphe
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Niveau Quatre");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Définit le niveau de puce
para4Format->set_Depth(3);

// Ajoute les paragraphes à la collection
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Écrit la présentation au format PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Gérer les Paragraphes avec une Liste Numérotée Personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) et d'autres qui vous permettent de gérer les paragraphes avec un numérotage ou un formatage personnalisé.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) à 2.
7. Créez la deuxième instance de paragraphe à l'aide de la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe à l'aide de la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisé :

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre de texte de l'autoshape créé
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Supprimez le paragraphe existant par défaut
textFrame->get_Paragraphs()->RemoveAt(0);

// Première liste
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"puce 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"puce 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"puce 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Définir l'Indentation des Paragraphes**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accédez à la référence de la diapositive pertinente via son index.
1. Ajoutez une forme rectangulaire [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) avec trois paragraphes à l'autoshape rectangulaire.
1. Masquez les lignes du rectangle.
1. Définissez l'indentation pour chaque [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code C++ vous montre comment définir l'indentation d'un paragraphe : 

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accédez à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoutez une AutoShape de type rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Ajoutez TextFrame au rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Ajout du premier Paragraphe
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"Titre de diapositive");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Ajout du premier Paragraphe
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

//Ajout au cadre de texte
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Enregistrez le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Définir l'Indentation Suspendue pour un Paragraphe**

Ce code C++ vous montre comment définir l'indentation suspendue pour un paragraphe :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Exemple");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Définir l'Indentation Suspendue pour un Paragraphe");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Ce code C# montre comment définir l'indentation suspendue pour un paragraphe : ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Gérer les Propriétés de Fin de Paragraphe pour un Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Obtenez la référence pour la diapositive contenant le paragraphe via sa position.
1. Ajoutez une forme rectangulaire [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) avec deux paragraphes au rectangle.
1. Définissez la `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de Fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment définir les propriétés de Fin pour les paragraphes dans PowerPoint : 

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accédez à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoutez une AutoShape de type rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Ajoutez TextFrame au rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Ajout du premier Paragraphe
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Texte d'exemple");

para1->get_Portions()->Add(port01);

// Ajout du deuxième Paragraphe
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Texte d'exemple 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Enregistrez le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Importer du Texte HTML dans des Paragraphes**

Aspose.Slides fournit un support amélioré pour l'importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code C++ est une implémentation des étapes pour importer des textes HTML dans des paragraphes : 

```c++
Pour des exemples complets et des fichiers de données, veuillez aller sur https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accédez à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoutez une AutoShape de type rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Réinitialisation de la couleur de remplissage par défaut
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Ajoutez TextFrame au rectangle
ashp->AddTextFrame(u" ");

// Accédez au cadre de texte
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Obtenez la collection de Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Effacer tous les paragraphes dans le cadre de texte ajouté
ParaCollection->Clear();

// Chargement du fichier HTML à l'aide d'un lecteur de flux
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Ajouter le texte à partir du lecteur de flux HTML dans le cadre de texte
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Créez l'objet Paragraph pour le cadre de texte
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Créez l'objet Portion pour le paragraphe
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Texte Aspose");

//Obtenez le format de portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Définissez la police pour la portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Définissez la propriété de gras de la police
pf->set_FontBold(NullableBool::True);

// Définissez la propriété italique de la police
pf->set_FontItalic(NullableBool::True);

// Définissez la propriété de soulignement de la police
pf->set_FontUnderline(TextUnderlineType::Single);

// Définissez la hauteur de la police
pf->set_FontHeight(25);

// Définissez la couleur de la police
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrez le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **Exporter le Texte des Paragraphes vers HTML**

Aspose.Slides fournit un support amélioré pour l'exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et chargez la présentation désirée.
2. Accédez à la référence de la diapositive pertinente via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ au StreamWriter et exportez vos paragraphes préférés.

Ce code C++ vous montre comment exporter les textes des paragraphes PowerPoint vers HTML : 

```c++
Pour des exemples complets et des fichiers de données, veuillez aller sur https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Chargez la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Accède à la première diapositive par défaut de la présentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Index désiré
int index = 0;

// Accédez à la forme ajoutée
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extraire le premier paragraphe au format HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Écrire les données des paragraphes vers HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```