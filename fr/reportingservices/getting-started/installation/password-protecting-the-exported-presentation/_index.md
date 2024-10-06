---
title: Protéger par mot de passe la présentation exportée
type: docs
weight: 90
url: /reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

Protéger par mot de passe une présentation prévient l'utilisation et l'accès non autorisés. La protection par mot de passe est utile si vous créez des rapports contenant des données sensibles ou des détails que seules certaines personnes de votre organisation devraient voir.

Cet article vous montre comment mettre à jour votre environnement Reporting Services ou Visual Studio pour vous permettre d'enregistrer des présentations avec protection par mot de passe.

{{% /alert %}} 
## **Ajout d'une protection par mot de passe aux présentations exportées dans un environnement Reporting Services**
Pour appliquer les changements ici, vous devez modifier des fichiers dans le répertoire où Microsoft SQL Server Reporting Services est installé.
### **Étape 1. Localiser le répertoire d'installation du serveur de rapports.**
Le répertoire racine pour Microsoft SQL Server est généralement C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Pour les systèmes x64, l'instance x86 de SQL Server est installée à C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 et 2008 : Il pourrait y avoir plusieurs instances de Microsoft SQL Server configurées sur la machine. Chacune occupe un sous-répertoire MSSQL.x différent, par exemple MSSQL.1, MSSQL.2, etc. Trouvez le bon répertoire C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer avant de continuer avec les étapes suivantes.

Tous les chemins utilisés ci-dessous font référence au répertoire d'installation de Microsoft SQL Server Reporting Services comme <Instance>.
### **Étape 2. Ajouter le code pour ajouter des mots de passe aux présentations exportées**
Remplacez les extensions de rendu Aspose.Slides pour Reporting Services existantes dans le fichier **rsreportserver.config**. Pour ce faire, ouvrez le fichier C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config. 

Trouvez les options de rendu listées immédiatement ci-dessous et remplacez-les par le code du segment qui suit.
#### **Trouver les options de rendu Aspose.Slides pour Reporting Service**
**<Render>**

``` xml

   ...

  <!--Commencer ici.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Fin ici.-->

</Render>

```
#### **Code de remplacement**
**<Render>**

``` xml

   ...

  <!--Commencer ici.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Fin ici.-->

</Render>

```
### **Ajout d'une protection par mot de passe pour les présentations exportées dans Visual Studio**
Pour appliquer les changements ici, vous devez modifier le fichier où le Microsoft Visual Studio Report Designer est installé.
### **Étape 1. Ouvrir le répertoire Visual Studio.**
- Pour s'intégrer avec le Report Designer de Visual Studio 2005, ouvrez le répertoire C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Pour s'intégrer avec le Report Designer de Visual Studio 2008, ouvrez le répertoire C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Étape 2. Ajouter le code pour ajouter un mot de passe aux présentations exportées.**
Remplacez les extensions de rendu Aspose.Slides pour Reporting Services existantes dans le fichier **rsreportserver.config**. Pour ce faire, ouvrez le fichier C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (où **<Version>** est “8” pour Visual Studio 2005 ou “9.0” pour Visual Studio 2008) et ajoutez ces lignes dans l'élément **<Render>**. Puis remplacez-les par le code dans le prochain segment de code.
#### **Trouver les options de rendu Aspose.Slides pour Reporting Service**
**<Render>**

``` xml

   ...

  <!--Commencer ici.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Fin ici.-->

</Render>

```
#### **Code de remplacement**
**<Render>**

``` xml

   ...

  <!--Commencer ici.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Fin ici.-->

</Render>

```