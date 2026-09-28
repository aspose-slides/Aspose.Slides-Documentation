---
title: Gestion des licences
type: docs
weight: 50
url: /fr/jasperreports/licensing/
description: "Découvrez ce que la version d'évaluation d'Aspose.Slides pour JasperReports ajoute aux fichiers exportés, et comment appliquer une licence dans JasperReports et JasperReports Server."
---
{{% alert color="info" title="Note" %}}
Aspose.Slides pour JasperReports est disponible en tant qu'evaluation gratuite, sans limite de temps, depuis la [page de téléchargement](https://releases.aspose.com/slides/jasperreport/). Les versions d'evaluation et sous licence du produit sont disponibles via le meme téléchargement.

Lorsque vous etes satisfait de l'evaluation, [achetez une licence](https://purchase.aspose.com/pricing/slides/jasperreports/). Assurez-vous de bien comprendre et d'accepter les conditions d'abonnement.

La licence est disponible en telechargement depuis la page de commande une fois la commande payee. La licence est un fichier XML en texte clair, signe numeriquement, qui contient des informations telles que le nom du client, le produit achete et le type de licence. Ne modifiez en aucun cas le contenu du fichier de licence : toute modification le rend invalide.

Telechargez la licence sur votre ordinateur et copiez-la dans le dossier approprie (par exemple le dossier de votre application ou **JasperReports\lib**).
{{% /alert %}}

## **Limitation de la version d'evaluation**
La version d'evaluation d'Aspose.Slides pour JasperReports (sans licence specifiee) exporte chaque page du rapport, mais ajoute un filigrane d'evaluation au centre de chaque diapositive ou page, dans les quatre formats de sortie (PPT, PPTX, PDF et HTML), comme le montre la figure ci-dessous. Consultez [Evaluer Aspose.Slides](/slides/fr/jasperreports/evaluate-aspose-slides/) pour plus de details.

![Le filigrane d'evaluation au centre d'une diapositive exportee](evaluation_watermark.png)

## **Appliquer une licence**
Il existe plusieurs facons d'appliquer une licence, selon que vous travaillez avec JasperReports ou JasperServer.

### **Appliquer une licence pour JasperReports**
Appelez la methode `setLicense` de la classe `License` avec un flux qui lit le fichier de licence, comme dans Aspose.Slides pour Java :

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Créez un objet flux contenant le fichier de licence.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instanciez la classe License.
            License license = new License();

            // Définissez la licence via l'objet flux.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Ou, transmettez le chemin du fichier de licence a l'exportateur via le parametre `ASExporterParameters.PPT_LICENSE`. Dans cet extrait, `jasperPrint` est un rapport rempli, comme dans [Votre premiere exportation](/slides/fr/jasperreports/#your-first-export) :

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Appliquer une licence sur JasperServer**
Definissez la propriete `licenseFile` du bean `pptExportParameters` dans *applicationContext.xml* avec le chemin du fichier de licence, comme indique dans [Integration with JasperServer](/slides/fr/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).