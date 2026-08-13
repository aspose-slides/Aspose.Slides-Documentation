---
title: Configuração de Demos
type: docs
weight: 70
url: /pt/jasperreports/demos-setup/
---
Todas as demos fornecidas com Aspose.Slides for JasperReports são demos padrão modificadas. É melhor copiar todas as demos para a pasta de demonstração do JasperReports:
...\jasperreports-x.x.x\demo\samples\

Use a sequência padrão de comandos para compilar e exportar relatórios:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
Por favor, não se esqueça de executar o HSQLDB com o banco de dados de teste para preencher os relatórios com dados e copiar aspose.slides.jasperreports.library-xx.x.jar da pasta \lib\JasperReports X.X.X - X.X.X do arquivo aspose-slides-xx.x-jasperreports.zip para o diretório &#60;InstallDir&#62;\lib.
{{% /alert %}} 

A maioria das demos (exceto Charts) já possuem apresentações geradas, portanto você pode pular todas as etapas “ant” e verificar os resultados imediatamente.