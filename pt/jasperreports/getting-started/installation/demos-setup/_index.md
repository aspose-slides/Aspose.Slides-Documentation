---
title: Configuração das Demonstrações
type: docs
weight: 70
url: /pt/jasperreports/demos-setup/
description: "Configure os projetos de demonstração a partir do download do Aspose.Slides for JasperReports, altere a classe exportadora que eles utilizam e compile‑os com Ant."
---
## **O que são as demonstrações**

A pasta *samples* do download do Aspose.Slides for JasperReports contém oito projetos de demonstração: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* e *xmldatasource*. Eles são demonstrações padrão do JasperReports, modificados para adicionar um destino de compilação `ppt` que exporta o relatório preenchido para PPT. O download não contém apresentações exportadas; você as cria ao compilar uma demonstração.

## **Altere a classe exportadora antes de compilar**

Na versão enviada, o código Java das demonstrações usa `com.aspose.slides.jasperreports.JRPptExporter`, uma classe que os jars atuais não contêm, portanto as demonstrações não compilam. Na classe de aplicação da demonstração (por exemplo, *ShapesApp.java* na demonstração *shapes*), substitua `JRPptExporter` por `ASPptExporter`, o exportador PPT no mesmo pacote. A demonstração *fonts* importa todo o pacote, então apenas o nome da classe no seu código é alterado.

As demonstrações também utilizam classes do JasperReports que versões posteriores do JasperReports removeram, como `JExcelApiExporter` e `JRExporterParameter.FONT_MAP`. Com a alteração acima, as demonstrações compilam da seguinte forma:

| Versão do JasperReports | Demonstrações que compilam |
| :- | :- |
| 5.5.1 | todas as oito |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **Compilar uma demonstração**

Cada *build.xml* de demonstração espera a estrutura de pastas de um projeto JasperReports: ele compila contra *../../../build/classes* e os jars em *../../../lib*, relativos à pasta da demonstração.

1. Copie a pasta da demonstração para *demo/samples* na pasta do seu projeto JasperReports.
2. Copie *aspose.slides.jasperreports.library-xx.x.jar* da subpasta *lib* do download que corresponde à sua versão do JasperReports para a pasta *lib* do projeto JasperReports. Veja [Installing Aspose.Slides for JasperReports](/slides/pt/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Coloque o jar da sua versão do JasperReports e os jars dos quais ele depende na mesma pasta *lib*. Além dos arquivos da demonstração, *build.xml* coloca apenas *build/classes* e os jars em *lib* no classpath, e *build/classes* contém classes do JasperReports somente após você compilar o JasperReports a partir do código‑fonte.
4. As demonstrações *charts*, *subreport* e *text* leem o banco de dados de exemplo HSQLDB do JasperReports (`jdbc:hsqldb:hsql://localhost`), portanto inicie seu servidor primeiro, como descrito em *samples/Readme.txt* do download. As demais demonstrações não precisam de banco de dados.
5. Na pasta da demonstração, compile a aplicação, compile o design do relatório, preencha‑o e exporte‑o para PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

O destino `ppt` grava a apresentação ao lado do relatório preenchido, com o nome do relatório (por exemplo, *LandscapeReport.ppt*).

Duas demonstrações precisam de mais do que os passos acima:

- A demonstração *images* carrega uma imagem de `http://jasperreports.sourceforge.net/jasperreports.png` ao exportar. Esse endereço agora redireciona para HTTPS, portanto a etapa `ppt` não gera apresentação até que você altere o endereço para `https://` em *ImagesReport.jrxml*. Com o JasperReports 6.4.0, a exportação dessa imagem falha mesmo via HTTPS.
- O relatório *xmldatasource* usa a fonte Arial. Em um sistema sem Arial, `ant fill` exibe que a fonte "não está disponível para a JVM" e não gera relatório preenchido, portanto `ant ppt` não tem nada para exportar. A compilação ainda indica sucesso, então verifique a saída de cada etapa.