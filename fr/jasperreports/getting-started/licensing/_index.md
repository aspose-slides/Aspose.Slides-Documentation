---
title: Licence
type: docs
weight: 50
url: /fr/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports est disponible en évaluation gratuite et illimitée depuis la [page de téléchargement](https://downloads.aspose.com/slides/fr/jasperreport). L'évaluation et les versions sous licence du produit utilisent le même téléchargement.

Lorsque vous êtes satisfait de l'évaluation, [acheter une licence](https://purchase.aspose.com/buy). Assurez‑vous de comprendre et d’accepter les conditions d’abonnement.

La licence est disponible en téléchargement depuis la page de commande après le paiement de celle‑ci. La licence est un fichier XML en texte clair, signé numériquement, qui contient des informations telles que le nom du client, le produit acheté et le type de licence. Ne modifiez en aucun cas le contenu du fichier de licence : cela rend la licence invalide.

Téléchargez la licence sur votre ordinateur et copiez‑la dans le dossier approprié (par exemple votre dossier d’application ou **JasperReports\lib**).
{{% /alert %}}

## **Limitation de la version d'évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre la fonctionnalité complète du produit, mais (lorsque vous enregistrez vos présentations) elle insère un filigrane d'évaluation au centre de chaque diapositive comme le montre la figure ci‑dessous :

![todo:image_alt_text](evaluation_watermark.png) 

## **Appliquer une licence**
Il existe plusieurs façons d'appliquer une licence, selon que vous travaillez sur JasperReports ou JasperServer.

### **Appliquer une licence pour JasperReports**
Utilisez un appel direct à la méthode setLicense similaire à Aspose.Slides pour Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Créer un objet stream contenant le fichier de licence
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instancier la classe License
    License license = new License();
	
    //Définir la licence via l'objet stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ou, définissez le paramètre d'exportation dans le code.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Appliquer une licence sur JasperServer**
Définissez le paramètre d'exportation dans le fichier applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```