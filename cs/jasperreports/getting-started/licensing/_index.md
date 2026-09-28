---
title: Licencování
type: docs
weight: 50
url: /cs/jasperreports/licensing/
description: "Zjistěte, co zkušební verze Aspose.Slides for JasperReports přidává do exportovaných souborů, a jak použít licenci v JasperReports a JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports je k dispozici jako bezplatná, časově neomezená zkušební verze ze [stránky ke stažení](https://releases.aspose.com/slides/cs/jasperreport/). Zkušební a licencované verze produktu jsou ke stažení ze stejného souboru.

Pokud jste se se zkušební verzí spokojeni, [zakupte licenci](https://purchase.aspose.com/pricing/slides/cs/jasperreports/). Ujistěte se, že rozumíte a souhlasíte s podmínkami předplatného.

Licence je k stažení na stránce objednávky po zaplacení objednávky. Licence je v čistém textu, digitálně podepsaný XML soubor, který obsahuje informace jako název klienta, zakoupený produkt a typ licence. Obsah licenčního souboru v žádném případě neupravujte: úprava zneplatní licenci.

Stáhněte licenci do svého počítače a zkopírujte ji do příslušné složky (například do složky aplikace nebo **JasperReports\lib**).
{{% /alert %}}

## **Omezení zkušební verze**
Zkušební verze Aspose.Slides for JasperReports (bez zadané licence) exportuje každou stránku zprávy, ale do středu každého snímku nebo stránky vloží zkušební vodoznak ve všech čtyřech výstupních formátech (PPT, PPTX, PDF a HTML), jak je znázorněno na obrázku níže. Další podrobnosti naleznete v [Evaluate Aspose.Slides](/slides/cs/jasperreports/evaluate-aspose-slides/).

![Zkušební vodoznak uprostřed exportovaného snímku](evaluation_watermark.png)

## **Použití licence**
Existuje několik způsobů, jak licenci použít, v závislosti na tom, zda pracujete s JasperReports nebo JasperServer.

### **Použití licence pro JasperReports**
Zavolejte metodu `setLicense` třídy `License` s proudem, který čte licenční soubor, stejně jako v Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Vytvořte objekt proudu obsahující licenční soubor.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Vytvořte instanci třídy License.
            License license = new License();

            // Nastavte licenci pomocí objektu proudu.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Nebo předávejte cestu k licenčnímu souboru exportéru v parametru `ASExporterParameters.PPT_LICENSE`. V tomto úryvku je `jasperPrint` vyplněná zpráva, jak je uvedeno v [Your first export](/slides/cs/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Použití licence v JasperServer**
Nastavte vlastnost `licenseFile` beanu `pptExportParameters` v *applicationContext.xml* na cestu k licenčnímu souboru, jak je ukázáno v [Integration with JasperServer](/slides/cs/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).