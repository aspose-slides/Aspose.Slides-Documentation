---
title: "Automatisation de la génération de PowerPoint en C++: créez facilement des présentations dynamiques"
linktitle: Automatisation de la génération de PowerPoint
type: docs
weight: 20
url: /fr/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- plateformes cloud
- automatiser la génération de PowerPoint
- générer des présentations programmatiquement
- automatisation de PowerPoint
- création dynamique de diapositives
- rapports d'entreprise automatisés
- automatisation PPT
- présentation C++
- C++
- Aspose.Slides
description: "Automatisez la création de diapositives sur les plateformes cloud avec Aspose.Slides pour C++—générez, modifiez et convertissez rapidement et de manière fiable les fichiers PowerPoint et OpenDocument."
---

## **Introduction**

Créer des présentations PowerPoint manuellement peut être une tâche chronophage et répétitive—surtout lorsque le contenu repose sur des données dynamiques qui changent fréquemment. Qu'il s'agisse de générer des rapports d'activité hebdomadaires, d'assembler du matériel pédagogique ou de produire des présentations commerciales prêtes pour les clients, l'automatisation peut faire gagner d'innombrables heures et garantir la cohérence entre les équipes.

Pour les développeurs C++, automatiser la création de présentations PowerPoint ouvre de puissantes possibilités. Vous pouvez intégrer la génération de diapositives dans des portails web, des outils de bureau, des services back‑end ou des plateformes cloud afin de convertir dynamiquement les données en présentations professionnelles et brandées—à la demande.

Dans cet article, nous explorerons les cas d’utilisation courants de la génération automatisée de PowerPoint dans les applications C++ (y compris les déploiements sur les plateformes cloud) et pourquoi cela devient une fonctionnalité essentielle des solutions modernes. De l'extraction de données commerciales en temps réel à la conversion de texte ou d'images en diapositives, l'objectif est de transformer un contenu brut en formats visuels structurés que votre audience peut comprendre instantanément.

## **Cas d’utilisation courants de l’automatisation PowerPoint en C++**

L’automatisation de la génération de PowerPoint est particulièrement utile dans les scénarios où le contenu des présentations doit être assemblé dynamiquement, personnalisé ou mis à jour fréquemment. Voici quelques-uns des cas d’utilisation réels les plus courants :

- **Rapports d’entreprise et tableaux de bord**
  Générer des résumés de ventes, des indicateurs clés de performance ou des rapports de performance financière en extrayant des données en direct depuis des bases de données ou des API.

- **Présentations commerciales et marketing personnalisées**
  Créer automatiquement des présentations de pitch spécifiques à chaque client à l’aide des données CRM ou de formulaires, assurant une rapidité d’exécution et une cohérence de la marque.

- **Contenu éducatif**
  Convertir du matériel d’apprentissage, des quiz ou des résumés de cours en présentations structurées pour les plateformes d‑e‑learning.

- **Insights alimentés par les données et l’IA**
  Utiliser le traitement du langage naturel ou des moteurs d’analyse pour transformer des données brutes ou des textes longs en présentations résumées.

- **Diapositives basées sur les médias**
  Assembler des présentations à partir d’images téléchargées, de captures d’écran annotées ou d’images clés vidéo accompagnées de descriptions.

- **Conversion de documents**
  Convertir automatiquement des documents Word, des PDF ou des saisies de formulaires en présentations visuelles avec un effort manuel minimal.

- **Outils pour développeurs et techniques**
  Créer des démonstrations techniques, des aperçus de documentation ou des journaux de modifications au format diapositive directement à partir du code ou du contenu markdown.

En automatisant ces flux de travail, les organisations peuvent mettre à l’échelle la création de contenu, maintenir la cohérence et libérer du temps pour des activités plus stratégiques.

## **Passons au code**

Pour cet exemple, nous avons choisi **[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)** pour illustrer l’automatisation PowerPoint grâce à son ensemble complet de fonctionnalités et sa facilité d’utilisation lors de la manipulation de présentations de manière programmatique.

Contrairement aux bibliothèques de bas niveau, qui obligent les développeurs à travailler directement avec la structure Open XML (engendrant souvent un code verbeux et difficile à lire), Aspose.Slides propose une API de haut niveau. Elle masque la complexité, permettant aux développeurs de se concentrer sur la logique de la présentation—telle que la mise en page, le formatage et la liaison de données—sans avoir besoin de comprendre en détail le format de fichier PowerPoint.

Bien qu’Aspose.Slides soit une bibliothèque commerciale, elle propose une version d’[essai gratuit](https://releases.aspose.com/slides/cpp/) capable d’exécuter pleinement les exemples présentés dans cet article. Dans le but de démontrer des concepts, de tester des fonctionnalités ou de créer une preuve de concept comme celle que nous abordons ici, l’essai est largement suffisant. Cela en fait une option pratique pour expérimenter l’automatisation de PowerPoint sans devoir acquérir immédiatement une licence.

Ok, parcourons la création d’une présentation d’exemple en utilisant du contenu réel.

### **Créer une diapositive titre**

Nous commencerons par créer une nouvelle présentation et ajouter une diapositive titre avec un titre principal et un sous‑titre.
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![Diapositive titre](slide_0.png)

### **Ajouter une diapositive avec un diagramme à colonnes**

Ensuite, nous créerons une diapositive affichant la performance des ventes régionales sous forme de diagramme à colonnes.
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![Diapositive avec le graphique](slide_1.png)

### **Ajouter une diapositive avec un tableau**

Nous allons maintenant ajouter une diapositive présentant les indicateurs de performance clés sous forme de tableau.
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![Diapositive avec le tableau](slide_2.png)

### **Ajouter une diapositive récapitulative avec puces**

Enfin, nous inclurons un résumé et un plan d’action à l’aide d’une simple liste à puces.
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![Diapositive avec le texte](slide_3.png)

### **Enregistrer la présentation**

Enfin, nous enregistrons la présentation sur le disque :
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Conclusion**

L’automatisation de la génération de PowerPoint dans les applications C++ offre des avantages évidents en termes d’économie de temps et de réduction des efforts manuels. En intégrant du contenu dynamique tel que des graphiques, des tableaux et du texte, les développeurs peuvent rapidement produire des présentations cohérentes et professionnelles—idéales pour les rapports d’entreprise, les réunions avec les clients ou le contenu éducatif.

Dans cet article, nous avons démontré comment automatiser la création d’une présentation à partir de zéro, y compris l’ajout d’une diapositive titre, de graphiques et de tableaux. Cette approche peut être appliquée à de nombreux cas d’utilisation où des présentations automatisées et basées sur les données sont nécessaires.

En exploitant les bons outils, les développeurs C++ peuvent automatiser efficacement la création de PowerPoint, améliorant ainsi la productivité et garantissant la cohérence des présentations.