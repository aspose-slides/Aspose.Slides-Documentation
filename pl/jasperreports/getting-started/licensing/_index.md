---
title: Licencjonowanie
type: docs
weight: 50
url: /pl/jasperreports/licensing/
description: "Dowiedz się, co wersja ewaluacyjna Aspose.Slides for JasperReports dodaje do wyeksportowanych plików oraz jak zastosować licencję w JasperReports i JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports jest dostępny jako bezpłatna, nieograniczona czasowo wersja ewaluacyjna ze [strony pobierania](https://releases.aspose.com/slides/pl/jasperreport/). Wersje ewaluacyjna i licencjonowana produktu są dostępne do pobrania z tego samego linku.

Gdy będziesz zadowolony z wersji ewaluacyjnej, [kup licencję](https://purchase.aspose.com/pricing/slides/pl/jasperreports/). Upewnij się, że rozumiesz i akceptujesz warunki subskrypcji.

Licencja jest dostępna do pobrania z strony zamówienia po opłaceniu zamówienia. Licencja jest plikiem XML w formie czystego tekstu, cyfrowo podpisanym, który zawiera informacje takie jak nazwa klienta, zakupiony produkt i typ licencji. Nie modyfikuj w żaden sposób zawartości pliku licencji: spowoduje to unieważnienie licencji.

Pobierz licencję na swój komputer i skopiuj ją do odpowiedniego folderu (na przykład do folderu aplikacji lub **JasperReports\lib**).
{{% /alert %}}

## **Evaluation Version Limitation**
Wersja ewaluacyjna Aspose.Slides for JasperReports (bez określonej licencji) eksportuje każdą stronę raportu, ale umieszcza znak wodny ewaluacji na środku każdego slajdu lub strony, we wszystkich czterech formatach wyjściowych (PPT, PPTX, PDF i HTML), jak pokazano na rysunku poniżej. Zobacz [Oceń Aspose.Slides](/slides/pl/jasperreports/evaluate-aspose-slides/) po szczegóły.

![Znak wodny wersji ewaluacyjnej na środku wyeksportowanego slajdu](evaluation_watermark.png)

## **Applying a License**
Istnieje kilka sposobów zastosowania licencji, w zależności od tego, czy pracujesz z JasperReports, czy JasperServer.

### **Applying a License for JasperReports**
Wywołaj metodę `setLicense` klasy `License` przekazując strumień odczytujący plik licencji, tak jak w Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Utwórz obiekt strumienia zawierający plik licencji.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Utwórz instancję klasy License.
            License license = new License();

            // Ustaw licencję za pomocą obiektu strumienia.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Lub przekaż ścieżkę do pliku licencji eksportującemu w parametrze `ASExporterParameters.PPT_LICENSE`. W tym fragmencie `jasperPrint` jest wypełnionym raportem, tak jak w [Twój pierwszy eksport](/slides/pl/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applying a License on JasperServer**
Ustaw właściwość `licenseFile` bean-a `pptExportParameters` w *applicationContext.xml* na ścieżkę pliku licencji, jak pokazano w [Integracja z JasperServer](/slides/pl/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).