---
title: Instalando Aspose.Slides for JasperReports
type: docs
weight: 40
url: /pt/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Escolha os jars do Aspose.Slides for JasperReports que correspondam à sua versão do JasperReports e adicione-os ao JasperReports, a um projeto Maven ou ao JasperReports Server."
---
## **Escolha os jars para a sua versão do JasperReports**

Aspose.Slides for JasperReports é distribuído como um arquivo ZIP na [página de download](https://releases.aspose.com/slides/jasperreport/). Sua pasta *lib* possui uma subpasta para cada intervalo de versões do JasperReports. Pegue os jars da subpasta que corresponde à versão do JasperReports que você usa:

| Versão do JasperReports | Subpasta do *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Não há subpasta para JasperReports 6.17.0 ou posterior, incluindo JasperReports 7. A subpasta *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* não contém jars, apenas uma nota de que o suporte a essas versões terminou no Aspose.Slides for JasperReports 17.6.

Cada subpasta contém dois jars; *xx.x* nos nomes indica a versão do produto:

- *aspose.slides.jasperreports.library-xx.x.jar* contém os exportadores para JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` e `ASHtmlExporter`) e a classe `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* contém as ações de exportação para JasperReports Server. Ele se baseia no jar de biblioteca, portanto o servidor sempre precisa de ambos os jars da mesma subpasta.

## **Adicionar o jar de biblioteca ao JasperReports ou à sua aplicação**

Copie *aspose.slides.jasperreports.library-xx.x.jar* da subpasta correspondente para a pasta *lib* do JasperReports ou para o classpath da sua aplicação. Sua aplicação poderá então criar os exportadores em código.

{{% alert color="info" title="Note" %}}
No Linux, o JasperReports precisa do fontconfig e de ao menos uma fonte instalada para preencher um relatório. Sem fontes, o preenchimento falha com o erro "Error initializing graphic environment".
{{% /alert %}}

## **Adicionar o jar de biblioteca a um projeto Maven**

O jar está incluído no ZIP em vez de estar disponível em um repositório Maven. Para usá‑lo em uma compilação Maven, instale‑o em seu repositório Maven local. Para a versão 26.6, execute este comando na pasta que contém o jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Em seguida, adicione‑o às dependências em *pom.xml*, juntamente com uma versão do JasperReports que a subpasta do jar cobre:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Os IDs de group e artifact são aqueles que você definiu no comando de instalação; eles apenas precisam corresponder. Um projeto completo que usa JasperReports 6.16.0 está em [Your first export](/slides/pt/jasperreports/#your-first-export).

## **Adicionar os jars ao JasperReports Server**

Copie ambos os jars da subpasta correspondente para a pasta *WEB-INF/lib* da aplicação web JasperReports Server e, em seguida, registre os exportadores conforme descrito em [Integration with JasperServer](/slides/pt/jasperreports/integration-with-jasperserver/).