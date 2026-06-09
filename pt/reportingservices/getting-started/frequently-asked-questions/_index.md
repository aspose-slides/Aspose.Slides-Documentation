---
title: Perguntas Frequentes
type: docs
weight: 110
url: /pt/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Esta página reúne várias perguntas frequentes sobre:

- [Formatos de arquivo suportados](#Supported-File-Formats).
- [Suporte para os serviços de relatórios Power BI](#Support-for-Power-BI-Reporting-services).
- [Instalação](#Installation).
- [Configuração de exportação](#Export-Configuration).

{{% /alert %}} 
### **Formatos de arquivo suportados**
#### **Q: Quais formatos podem ser usados para exportar relatórios usando Aspose.Slides for Reporting Services?**
**A**: O Aspose.Slides for Reporting Services permite exportar qualquer relatório nos formatos PPT, PPS, PPTX, PPSX, XPS ou RPL.
### **Suporte para os serviços de relatórios Power BI**
#### **Q: O Aspose.Slides for Reporting Services oferece suporte ao Power BI?**
**A**: Sim. O Aspose.Slides for Reporting Services oferece suporte à exportação de relatórios paginados (RDL) no Power BI.
### **Instalação**
#### **Q: O programa de instalação não inicia. A instalação manual não produz o resultado desejado.**
**A** : Certifique-se de que o .NET Framework 3.5 esteja instalado no seu sistema.
#### **Q: Opções de exportação ausentes após a instalação do Aspose.Slides for Reporting Services.**
**A**: Se algum CodeGroup em rssrvpolicy.config não funcionar corretamente, o analisador do arquivo de configuração pode pular as últimas seções do grupo. Portanto, mova todos os CodeGroups associados ao Aspose.Slides for Reporting Services para o início do bloco que contém os CodeGroups do Aspose.Slides for Reporting Services.
#### **Q: Não foi possível carregar o arquivo ou assembly Aspose.Slides.ReportingServices (Permissão de execução não pode ser adquirida \ Exceção de HRESULT: 0x80131418).**
**A**: O código de erro (0x80131418) indica que o módulo dll não possui direitos suficientes. Isso pode ser devido a um recurso de segurança que bloqueou o acesso total ao arquivo .dll se ele foi obtido de outro computador. Isso pode ser corrigido abrindo a janela de propriedades do arquivo dll e clicando no botão "Desbloquear" no painel "Segurança".
#### **Q: Não foi possível encontrar a licença 'Aspose.Slides.Reporting.Services.lic'.**
**A**: O arquivo de licença deve estar localizado ao lado da dll ou no diretório Program Files(x86)\Aspose\Slides\.
### **Configuração de exportação**
#### **Q: Como posso alterar a cor dos hyperlinks em um relatório exportado?**
**A**: Cada extensão de renderização do Aspose.Slides for Reporting Services no rsreportserver.config possui sua própria configuração. Para alterar a cor do hyperlink, defina o valor desejado na seção <HyperlinkColor>.
#### **Q: Em apresentações exportadas, o texto nas tabelas é esticado verticalmente.**
**A**: Isso é feito para tornar o documento mais fácil de ler. Para exibir o texto na tabela como ele aparece no relatório, defina a extensão do Aspose.Slides for Reporting Services como "Normal" no arquivo de configuração rsreportserver.config.