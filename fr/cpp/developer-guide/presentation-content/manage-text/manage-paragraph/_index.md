---
title: Gérer les paragraphes de texte PowerPoint en C++
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer la puce
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez la mise en forme des paragraphes avec Aspose.Slides pour C++ — optimisez l’alignement, l’espacement et le style dans les présentations PPT, PPTX et ODP en C++."
---
## **Introduction**

Aspose.Slides fournit toutes les interfaces et classes dont vous avez besoin pour travailler avec les textes, paragraphes et portions PowerPoint en C++.

* Aspose.Slides fournit l’interface [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) pour vous permettre d’ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l’interface [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) pour vous permettre d’ajouter des objets représentant des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d’objets iPortions).
* Aspose.Slides fournit l’interface [IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/) pour vous permettre d’ajouter des objets représentant des textes et leurs propriétés de mise en forme.

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de mise en forme grâce à ses objets sous‑jacents `IPortion`.

## **Add Multiple Paragraphs Containing Multiple Portions**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un rectangle [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé au [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) et ajoutez‑les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez les options de mise en forme souhaitées à chaque portion à l’aide des propriétés de mise en forme exposées par l’objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code C++ est une implémentation des étapes pour ajouter des paragraphes contenant des portions :

```c++
// Le chemin du répertoire des documents.
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

// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Manage Paragraph Bullets**

Les listes à puces vous permettent d’organiser et de présenter les informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/).
7. Définissez le `Type` de puce du paragraphe sur `Symbol` et indiquez le caractère de la puce.
8. Définissez le `Text` du paragraphe.
9. Définissez le `Indent` du paragraphe pour la puce.
10. Attribuez une couleur à la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code C++ montre comment ajouter une puce de paragraphe :

```c++
// Le chemin du répertoire des documents.
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
	
// définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
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

// définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Définir la hauteur de la puce
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Ajouter le paragraphe au cadre de texte
txtFrame->get_Paragraphs()->Add(paragraph2);


// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Manage Picture Bullets**

Les listes à puces vous permettent d’organiser et de présenter les informations rapidement et efficacement. Les paragraphes d’images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/).
7. Chargez l’image dans [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) et indiquez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Attribuez une couleur à la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter et gérer des puces d’image :

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accède à la première diapositive
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancie l'image pour les puces
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Ajoute et accède à l'AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre de texte de l'AutoShape
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

// Ajoute le paragraphe au cadre de texte
paragraphs->Add(paragraph);

// Enregistre la présentation en fichier PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Enregistre la présentation en fichier PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Manage Multilevel Bullets**

Les listes à puces vous permettent d’organiser et de présenter les informations rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la seconde instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
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

// Accède au cadre de texte de l'AutoShape créé
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Vide le paragraphe par défaut
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

// Enregistre la présentation en tant que fichier PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Manage a Paragraph with a Custom Numbered List**

L’interface [IBulletFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) et d’autres qui permettent de gérer des paragraphes avec une numérotation ou une mise en forme personnalisée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez un [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) à 2.
7. Créez la seconde instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter et gérer des paragraphes avec une numérotation ou une mise en forme personnalisée :

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accède au cadre de texte de l'autoshape créé
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Supprime le paragraphe existant par défaut
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

## **Set First-Line Indent for a Paragraph**

Utilisez la méthode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour contrôler le retrait de première ligne d’un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes suivantes restent alignées sur le corps du paragraphe.

Utilisez [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) lorsque vous devez déplacer tout le paragraphe. Utilisez [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) lorsque vous ne devez déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs `Indent` pour démontrer l’effet du retrait de première ligne sur la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un rectangle [AutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez des valeurs différentes de [Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour chacun d’eux.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait de paragraphe :

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

## **Set Hanging Indent for a Paragraph**

Un retrait suspendu est une mise en page de paragraphe dans laquelle la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/). Définissez le retrait sur une valeur négative pour décaler la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) définit la position gauche du corps du paragraphe, et [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une valeur positive pour `MarginLeft` et une valeur négative pour `Indent`.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes enroulées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un rectangle [AutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive de [MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) pour chaque paragraphe.
6. Définissez une valeur négative de [Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour obtenir l’effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

## **Manage End Paragraph Run Properties**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) avec deux paragraphes au rectangle.
1. Définissez le `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés End pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C++ montre comment définir les propriétés End pour les paragraphes dans PowerPoint :

```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accéder à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Ajouter un TextFrame au Rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Ajout du premier paragraphe
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Ajout du deuxième paragraphe
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

## **Import HTML Text into Paragraphs**

Aspose.Slides fournit un support amélioré pour l’importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un [autoshape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez au `autoshape` [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) 
5. Supprimez le paragraphe par défaut du `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code C++ est une implémentation des étapes pour importer des textes HTML dans des paragraphes :

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin du répertoire des documents.
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
	
// Ajouter un TextFrame au Rectangle
ashp->AddTextFrame(u" ");

// Accéder au cadre de texte
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Obtenir la collection de paragraphes
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Effacer tous les paragraphes du cadre de texte ajouté
ParaCollection->Clear();

// Charger le fichier HTML à l'aide d'un lecteur de flux
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Ajouter le texte du lecteur de flux HTML dans le cadre de texte
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Créer l'objet Paragraph pour le cadre de texte
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

// Définir la hauteur de la police
pf->set_FontHeight(25);

// Définir la couleur de la police
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrer le PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Export Paragraph Text to HTML**

Aspose.Slides fournit un support amélioré pour l’exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez à la [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ à StreamWriter et exportez les paragraphes souhaités.

Ce code C++ montre comment exporter les textes de paragraphes PowerPoint vers HTML :

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Le chemin du répertoire des documents.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Charger la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Accéder à la première diapositive par défaut de la présentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Index désiré
int index = 0;

// Accéder à la forme ajoutée
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extraction du premier paragraphe en HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Écrire les données des paragraphes en HTML en fournissant l'index de début du paragraphe, le nombre total de paragraphes à copier
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Save a Paragraph as an Image**

Dans cette section, nous explorerons deux exemples montrant comment enregistrer un paragraphe de texte, représenté par l’interface [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/), sous forme d’image. Les deux exemples incluent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `GetImage` de l’interface [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), le calcul des limites du paragraphe dans la forme, et son exportation en tant qu’image bitmap. Ces approches vous permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique en tant qu’image séparée tout en conservant les dimensions et la mise en forme exactes du texte.

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

![L’image du paragraphe](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée comme image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des documents imprimés de haute qualité.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne automatique dans un cadre de texte ?**

Oui. Utilisez la méthode de retour à la ligne du cadre de texte ([set_WrapText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframeformat/set_wraptext/)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une portion unique) pour connaître sa position et sa taille précises sur la diapositive.

**Où est contrôlé l’alignement des paragraphes (gauche/droite/centré/justifié) ?**

[Alignment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraphformat/set_alignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraphformat/); il s’applique à tout le paragraphe quel que soit le format des portions individuelles.

**Puis‑je définir une langue de vérification orthographique pour seulement une partie d’un paragraphe (par ex. un mot) ?**

Oui. La langue est définie au niveau de la portion à l’aide de ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_languageid/)), ce qui permet à plusieurs langues de coexister dans un même paragraphe.