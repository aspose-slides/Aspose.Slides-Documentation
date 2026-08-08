---
title: Licenciamento
type: docs
weight: 50
url: /pt/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides para JasperReports está disponível como avaliação gratuita ilimitada a partir da [página de download](https://downloads.aspose.com/slides/pt/jasperreport). A versão de avaliação e a versão licenciada do produto são o mesmo download.

Quando estiver satisfeito com a avaliação, [compre uma licença](https://purchase.aspose.com/buy). Certifique-se de que entende e concorda com os termos da assinatura.

A licença está disponível para download na página de pedido depois que o pedido for pago. A licença é um arquivo XML em texto simples, assinada digitalmente, que contém informações como o nome do cliente, o produto adquirido e o tipo de licença. Não modifique o conteúdo do arquivo de licença de forma alguma: isso invalida a licença.

Baixe a licença para o seu computador e copie‑a para a pasta apropriada (por exemplo, a pasta da sua aplicação ou **JasperReports\lib**).
{{% /alert %}}

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) fornece a funcionalidade completa do produto, mas (quando você salva suas apresentações) ela insere uma marca d'água de avaliação no centro de cada slide, conforme mostrado na figura abaixo:

![todo:image_alt_text](evaluation_watermark.png) 

## **Aplicando uma Licença**
Existem várias maneiras de aplicar uma licença, dependendo se você está trabalhando com JasperReports ou JasperServer.

### **Aplicando uma Licença para JasperReports**
Use uma chamada direta ao método setLicense semelhante ao Aspose.Slides para Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Crie um objeto de fluxo contendo o arquivo de licença
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instancie a classe License
    License license = new License();
	
    //Defina a licença através do objeto de fluxo
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ou, defina o parâmetro exporter no código.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicando uma Licença no JasperServer**
Defina o parâmetro exporter no applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```