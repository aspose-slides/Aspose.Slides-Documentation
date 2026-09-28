---
title: Licencelés
type: docs
weight: 50
url: /hu/jasperreports/licensing/
description: "Ismerje meg, hogy az Aspose.Slides for JasperReports értékelő verziója milyen változtatásokat végez az exportált fájlokban, és hogyan lehet licencet alkalmazni a JasperReports és a JasperReports Server esetén."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports ingyenes, időkorlát nélküli értékelő verzióban elérhető a [letöltő oldalon](https://releases.aspose.com/slides/jasperreport/). Az értékelő és a licenszelt verziók ugyanazzal a letöltéssel érhetők el.

Ha elégedett vagy az értékelő verzióval, [vásárolj licencet](https://purchase.aspose.com/pricing/slides/jasperreports/). Győződj meg róla, hogy megérted és elfogadod az előfizetési feltételeket.

A licenc a megrendelés oldalon tölthető le, miután a rendelés ki lett fizetve. A licenc egy tiszta szöveges, digitálisan aláírt XML fájl, amely információkat tartalmaz, például az ügyfél nevét, a megvásárolt terméket és a licenc típusát. Ne módosítsd a licencfájl tartalmát semmilyen módon: ez érvényteleníti a licencet.

Töltsd le a licencet a számítógépedre, és másold a megfelelő mappába (például az alkalmazásod mappájába vagy a **JasperReports\lib** mappába).

{{% /alert %}}

## **Értékelő verzió korlátozása**
Az Aspose.Slides for JasperReports értékelő verziója (licenc nélkül) exportálja a jelentés minden oldalát, de egy értékelő vízjelet helyez el minden dia vagy oldal közepén mind a négy kimeneti formátumban (PPT, PPTX, PDF és HTML), ahogy az alábbi ábrán látható. A részletekért lásd a [Evaluáld az Aspose.Slides](/slides/hu/jasperreports/evaluate-aspose-slides/).

![Az értékelő vízjel a exportált dia közepén](evaluation_watermark.png)

## **Licenc alkalmazása**
Számos módja van a licenc alkalmazásának, attól függően, hogy JasperReports-on vagy JasperServer-en dolgozol.

### **Licenc alkalmazása JasperReports esetén**
Hívd meg a `License` osztály `setLicense` metódusát egy olyan stream‑kel, amely beolvassa a licenc fájlt, az Aspose.Slides for Java példájához hasonlóan:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Hozzon létre egy adatfolyam objektumot, amely a licencfájlt tartalmazza.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Példányosítsa a License osztályt.
            License license = new License();

            // Állítsa be a licencet az adatfolyam objektumon keresztül.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Vagy add meg a licencfájl elérési útját a exportálónak az `ASExporterParameters.PPT_LICENSE` paraméterben. Ebben a részletben a `jasperPrint` egy kitöltött jelentés, ahogy a [Az első exportod](/slides/hu/jasperreports/#your-first-export) példában:

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Licenc alkalmazása JasperServer-en**
Állítsd be a `pptExportParameters` bean `licenseFile` tulajdonságát az *applicationContext.xml* fájlban a licencfájl elérési útjára, ahogy a [Integráció JasperServer-rel](/slides/hu/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) példában látható.