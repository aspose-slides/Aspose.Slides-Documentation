---
title: Nastavení demo projektů
type: docs
weight: 70
url: /cs/jasperreports/demos-setup/
description: "Nastavte demo projekty ze stažení Aspose.Slides for JasperReports, změňte třídu exportéru, kterou používají, a sestavte je pomocí Antu."
---
## **Co jsou demoa**

Složka *samples* ze stažení Aspose.Slides for JasperReports obsahuje osm demo projektů: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* a *xmldatasource*. Jedná se o standardní ukázky JasperReports, upravené tak, aby přidávaly build target `ppt`, který exportuje vyplněnou zprávu do PPT. Stažení neobsahuje žádné exportované prezentace; vytvoříte je sestavením demo ukázky.

## **Změňte třídu exportéru před sestavením**

Ve výchozím stavu používá Java kód demoa `com.aspose.slides.jasperreports.JRPptExporter`, třídu, která v aktuálních jar souborech není, takže demoa se neskompilují. V aplikační třídě demoa (například *ShapesApp.java* v demu *shapes*) nahraďte `JRPptExporter` za `ASPptExporter`, PPT exportér ve stejném balíčku. Demo *fonts* importuje celý balíček, takže se mění jen název třídy v jeho kódu.

Demo také používají třídy JasperReports, které byly v novějších verzích JasperReports odstraněny, jako např. `JExcelApiExporter` a `JRExporterParameter.FONT_MAP`. S výše uvedenou změnou se demoa kompilují takto:

| JasperReports version | Demos that compile |
| :- | :- |
| 5.5.1 | všechny osm |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* a *xmldatasource* |
| 6.16.0 | *charts* |

## **Sestavte demo**

Každý *build.xml* demoa očekává strukturu složek projektu JasperReports: kompiluje proti *../../../build/classes* a jar souborům v *../../../lib*, relativně k složce demoa.

1. Zkopírujte složku demoa do *demo/samples* ve složce projektu JasperReports.
2. Kopírujte *aspose.slides.jasperreports.library-xx.x.jar* z podsložky *lib* ve stažení, která odpovídá vaší verzi JasperReports, do složky *lib* projektu JasperReports. Viz [Installing Aspose.Slides for JasperReports](/slides/cs/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Umístěte jar vaší verze JasperReports a jar soubory, na nichž závisí, do stejné složky *lib*. Kromě souborů demoa, *build.xml* přidá na classpath jen *build/classes* a jar soubory pod *lib*, a *build/classes* obsahuje třídy JasperReports až po kompilaci JasperReports ze zdrojového kódu.
4. *charts*, *subreport* a *text* demoa čtou ukázkovou databázi HSQLDB JasperReports (`jdbc:hsqldb:hsql://localhost`), proto nejprve spusťte její server, jak je popsáno v *samples/Readme.txt* ve stažení. Ostatní demoa nevyžadují databázi.
5. Ve složce demoa zkompilujte aplikaci, zkompilujte návrh zprávy, vyplňte jej a exportujte do PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Cíl `ppt` zapíše prezentaci vedle vyplněné zprávy, pojmenovanou podle zprávy (např. *LandscapeReport.ppt*).

Dvě demoa vyžadují více než výše uvedené kroky:

- *images* demo načítá jeden obrázek z `http://jasperreports.sourceforge.net/jasperreports.png` při exportu. Tato adresa nyní přesměrovává na HTTPS, takže krok `ppt` nevytvoří žádnou prezentaci, dokud nezměníte adresu na `https://` v *ImagesReport.jrxml*. S JasperReports 6.4.0 selhává export tohoto obrázku i přes HTTPS.
- *xmldatasource* zpráva používá font Arial. Na systému bez Arial `ant fill` vypíše, že font "is not available to the JVM" a nevytvoří vyplněnou zprávu, takže `ant ppt` nemá co exportovat. Sestavení i tak hlásí úspěch, proto zkontrolujte výstup každého kroku.