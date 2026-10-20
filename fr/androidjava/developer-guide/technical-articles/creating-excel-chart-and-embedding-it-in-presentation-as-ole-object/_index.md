---
title: Créer des graphiques Excel et les intégrer dans des présentations en tant qu'objets OLE
type: docs
weight: 30
url: /fr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- intégrer le graphique
- objet OLE
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells pour Android via Java et intégrer le classeur dans une présentation PowerPoint avec Aspose.Slides pour Android via Java, incluant un aperçu du graphique."
---
## **Aperçu**

Cet article montre comment créer un graphique à colonnes Excel avec Aspose.Cells for Android via Java et intégrer son classeur dans une présentation PowerPoint avec Aspose.Slides for Android via Java. Le classeur intégré contient à la fois les données source et le graphique. Un aperçu PNG distinct affiche le graphique sur la diapositive avant que l'objet OLE ne soit activé.

Le résultat est un objet Excel intégré, et non un graphique PowerPoint natif. Modifier le classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation Excel compatible.

## **Prérequis**

Ajoutez Aspose.Cells for Android via Java et Aspose.Slides for Android via Java aux dépendances de votre projet. Appelez `ExcelChartEmbedding.createPresentation(getFilesDir())` depuis une activité Android. Microsoft Office n'est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d'entrée n'est nécessaire: l'exemple crée les données et le graphique en mémoire, puis écrit `OutputChart.pptx` dans le répertoire interne des fichiers de l'application. Appliquez les licences des deux produits lorsque vous exécutez en dehors du mode d'évaluation.

## **Comment l'intégration fonctionne**

1. Créer un classeur contenant une feuille de données et une feuille de graphique.
1. Rendre la feuille de graphique active afin que le classeur s'ouvre sur le graphique.
1. Définir la plage d'affichage OLE du classeur et rendre le graphique au format PNG.
1. Enregistrer le classeur au format XLSX en mémoire et intégrer ces octets dans une diapositive.
1. Attribuer le PNG comme aperçu de l'objet OLE et enregistrer la présentation au format PPTX.

Les plages d'affichage du classeur et le cadre sur la diapositive ont des rôles différents. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) accepte des indices de ligne et de colonne de début/fin basés sur zéro. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) accepte à la place la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L'exemple utilise l'indice de ligne 55 et l'indice de colonne 25 comme limites inférieure droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L'exemple l'ajuste à l'intérieur de la diapositive et le centre tout en conservant le ratio d'aspect du PNG, plutôt que d'étirer l'aperçu pour remplir la diapositive.

## **Créer et intégrer le graphique**

L'exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série du graphique. `ChartSheet` est sélectionnée comme feuille active avant l'enregistrement du classeur.

Le classeur est explicitement enregistré au format XLSX, correspondant à l'extension `xlsx` passée à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). Le PNG est chargé directement à partir de ses octets sans conversion bitmap intermédiaire. L'assigner via [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) remplace le substitut OLE par défaut.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // Rendre l'aperçu du graphique et sérialiser le classeur modifiable séparément.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // Adapter l'aperçu à l'intérieur de la diapositive sans changer son ratio d'aspect.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```
## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel intégré et un aperçu du graphique. Le classeur contient les données d'origine et un graphique à colonnes avec quatre séries. L'aperçu est centré sur la diapositive et conserve ses proportions.

![Graphique à colonnes Excel affiché comme aperçu d'un classeur intégré](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double-cliquez sur l'objet pour activer et modifier le classeur intégré. L'activation et la modification dépendent du support OLE de l'application hôte et des paramètres de sécurité.

## **FAQ**

**Pourquoi une image d'aperçu est‑elle nécessaire ?**

Le classeur intégré et son aperçu de diapositive sont du contenu distinct. Fournissez une image du graphique afin que la diapositive montre le graphique au lieu du placeholder par défaut « EMBEDDED OLE OBJECT ». Voir [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**L'aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**

Considérez l'aperçu comme une capture instantanée. Lors de la mise à jour des données du classeur par programme, régénérez l'image du graphique et remplacez l'aperçu ainsi que les données du classeur intégré.

**Puis‑je utiliser XLS au lieu de XLSX ?**

Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension des données intégrées. L'extension doit correspondre au format réel du classeur ; changer uniquement l'extension ne convertit pas les données.

**Pourquoi l'objet peut‑il changer de taille après activation ?**

L'application hôte peut mettre à jour la présentation de l'objet OLE lorsqu'elle active le classeur. La plage d'affichage OLE du classeur et les dimensions du cadre de la diapositive sont toutes deux importantes. Voir [Solution fonctionnelle pour le redimensionnement de feuille de calcul](/slides/fr/androidjava/working-solution-for-worksheet-resizing/).

## **Sections connexes**

- [Solution fonctionnelle pour le redimensionnement de feuille de calcul](/slides/fr/androidjava/working-solution-for-worksheet-resizing/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Gérer OLE](/slides/fr/androidjava/manage-ole/)