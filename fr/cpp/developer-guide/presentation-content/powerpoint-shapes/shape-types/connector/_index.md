---
title: Connecteur
type: docs
weight: 10
url: /cpp/connector/
keywords: "Connecter des formes, connecteurs, formes PowerPoint, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Connecter des formes PowerPoint en C++"
---

Un connecteur PowerPoint est une ligne spéciale qui connecte ou relie deux formes ensemble et reste attachée aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée.

Les connecteurs sont généralement connectés à des *points de connexion* (points verts), qui existent sur toutes les formes par défaut. Les points de connexion apparaissent lorsqu'un curseur s'approche d'eux.

Les *points d'ajustement* (points orange), qui n'existent que sur certains connecteurs, sont utilisés pour modifier les positions et les formes des connecteurs.

## **Types de Connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, en angle et courbés.

Aspose.Slides fournit ces connecteurs :

| Connecteur                      | Image                                                        | Nombre de points d'ajustement |
| ------------------------------- | ------------------------------------------------------------ | ------------------------------ |
| `ShapeType.Line`                | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                              |
| `ShapeType.StraightConnector1`  | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                              |
| `ShapeType.BentConnector2`      | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                              |
| `ShapeType.BentConnector3`      | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                              |
| `ShapeType.BentConnector4`      | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                              |
| `ShapeType.BentConnector5`      | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                              |
| `ShapeType.CurvedConnector2`    | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                              |
| `ShapeType.CurvedConnector3`    | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                              |
| `ShapeType.CurvedConnector4`    | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                              |
| `ShapeType.CurvedConnector5`    | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                              |

## **Connecter des Formes à l'Aide de Connecteurs**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtenez une référence de la diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) à la diapositive en utilisant la méthode `AddAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `AddConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur. 
1. Appelez la méthode `Reroute` pour appliquer le chemin de connexion le plus court.
1. Enregistrez la présentation. 

Ce code C++ vous montre comment ajouter un connecteur (un connecteur en coin) entre deux formes (une ellipse et un rectangle) :

```c++
// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Charge la présentation désirée
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accède à la collection de formes pour une diapositive spécifique
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Ajoute une forme d'ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Ajoute une forme de rectangle
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Ajoute une forme de connecteur à la collection de formes de la diapositive
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Connecte les formes en utilisant le connecteur
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// Appelle reroute qui définit le chemin le plus court automatique entre les formes
	connector->Reroute();
	
	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="REMARQUE"  color="warning"   %}} 

La méthode `connector->Reroute` réachemine un connecteur et le force à prendre le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut changer les indices des points `StartShapeConnectionSiteIndex` et `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Spécifiez un Point de Connexion**

Si vous souhaitez qu'un connecteur relie deux formes en utilisant des points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtenez une référence d'une diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) à la diapositive en utilisant la méthode `AddAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `AddConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur. 
1. Définissez vos points de connexion préférés sur les formes. 
1. Enregistrez la présentation.

Ce code C++ démontre une opération où un point de connexion préféré est spécifié :

```c++
// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Charge la présentation désirée
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accède à la collection de formes pour une diapositive spécifique
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Ajoute une forme d'ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Ajoute une forme de rectangle
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Ajoute une forme de connecteur à la collection de formes de la diapositive
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Connecte les formes en utilisant le connecteur
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Définit l'indice du point de connexion préféré sur la forme Ellipse
	int wantedIndex = 6;

	// Vérifie si l'indice préféré est inférieur au nombre maximum d'indices de site
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Définit le point de connexion préféré sur la forme Ellipse
		connector->set_StartShapeConnectionSiteIndex(wantedIndex);
	}

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Ajuster le Point de Connecteur**

Vous pouvez ajuster un connecteur existant à travers ses points d'ajustement. Seuls les connecteurs avec des points d'ajustement peuvent être modifiés de cette manière. Voir le tableau sous **[Types de connecteurs.](/slides/cpp/connector/#types-of-connectors)** 

#### **Cas Simple**

Considérons un cas où un connecteur entre deux formes (A et B) passe par une troisième forme (C) :

![connector-obstruction](connector-obstruction.png)

Code :

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette manière :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Cas Complexes** 

Pour effectuer des ajustements plus compliqués, vous devez prendre en compte ces choses :

* Un point ajustable d'un connecteur est fortement lié à une formule qui calcule et détermine sa position. Donc, des changements dans la localisation du point peuvent altérer la forme du connecteur.
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés du point de départ d'un connecteur à son point de fin.
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur de la forme d'un connecteur. 
  * La forme est limitée par les points de départ et de fin du connecteur multipliés par 1000. 
  * Le premier point, le deuxième point et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur et le pourcentage de la largeur (à nouveau).
* Pour les calculs qui déterminent les coordonnées des points d'ajustement d'un connecteur, vous devez prendre en compte la rotation du connecteur et sa réflexion. **Remarque** que l'angle de rotation pour tous les connecteurs montrés sous **[Types de connecteurs](/slides/cpp/connector/#types-of-connectors)** est 0.

#### **Cas 1**

Considérons un cas où deux objets de cadre de texte sont liés ensemble par un connecteur :

![connector-shape-complex](connector-shape-complex.png)

Code :

```c++
// Instancie une classe de présentation qui représente un fichier PPTX
auto pres = System::MakeObject<Presentation>();
// Obtient la première diapositive de la présentation
auto slide = pres->get_Slides()->idx_get(0);
// Obtient les formes de la première diapositive
auto shapes = slide->get_Shapes();
// Ajoute des formes qui seront reliées ensemble par un connecteur
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"De");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"À");
// Ajoute un connecteur
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Spécifie la direction du connecteur
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Spécifie l'épaisseur de la ligne du connecteur
lineFormat->set_Width(3);
// Spécifie la couleur du connecteur
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Lie les formes ensemble avec le connecteur
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Obtient les points d'ajustement pour le connecteur
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Ajustement**

Nous pouvons changer les valeurs des points d'ajustement du connecteur en augmentant le pourcentage de largeur et de hauteur correspondants de 20 % et 200 %, respectivement :

```c++
// Change les valeurs des points d'ajustement
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Le résultat :

![connector-adjusted-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permet de déterminer les coordonnées et la forme des parties individuelles du connecteur, créons une forme qui correspond à la composante horizontale du connecteur au point connector.Adjustments[0] :

```c++
// Dessine la composante verticale du connecteur
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Le résultat :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **Cas 1**, nous avons démontré une opération d'ajustement de connecteur simple en utilisant des principes de base. Dans des situations normales, vous devez prendre en compte la rotation du connecteur et son affichage (qui sont réglés par connector.Rotation, connector.Frame.FlipH, et connector.Frame.FlipV). Nous allons maintenant démontrer le processus.

Tout d'abord, ajoutons un nouvel objet de cadre de texte (**À 1**) à la diapositive (pour des raisons de connexion) et créons un nouveau connecteur (vert) qui le relie aux objets que nous avons déjà créés.

```c++
// Crée un nouvel objet de liaison
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"À 1");
// Crée un nouveau connecteur
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Connecte les objets à l'aide du nouveau connecteur créé
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Obtient les points d'ajustement du connecteur
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Change les valeurs des points d'ajustement
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```



Le résultat :

![connector-adjusted-3](connector-adjusted-3.png)

Ensuite, créons une forme qui correspondra à la composante horizontale du connecteur qui passe par le nouveau point d'ajustement du connecteur connector.Adjustments[0]. Nous utiliserons les valeurs des données du connecteur pour connector.Rotation, connector.Frame.FlipH, et connector.Frame.FlipV et appliquerons la formule de conversion de coordonnées populaire pour la rotation autour d'un point donné x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, donc voici le code correspondant :

```c++

```

Le résultat :

![connector-adjusted-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement compliqués (points d'ajustement avec des angles de rotation). En utilisant les connaissances acquises, vous pouvez développer votre propre modèle (ou écrire un code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d'ajustement d'un connecteur en fonction de coordonnées spécifiques de diapositive.

## **Trouver l'Angle des Lignes de Connecteur**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtenez une référence de la diapositive par son index.
1. Accédez à la forme de ligne du connecteur.
1. Utilisez la largeur de ligne, la hauteur, la hauteur du cadre de forme et la largeur du cadre de forme pour calculer l'angle.

Ce code C++ démontre une opération dans laquelle nous avons calculé l'angle pour une forme de ligne de connecteur :

```c++
void ConnectorLineAngle()
{

	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Charge la présentation désirée
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Accède à la collection de formes des diapositives
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```