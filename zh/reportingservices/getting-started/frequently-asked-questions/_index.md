---
title: 常见问题解答
type: docs
weight: 110
url: /reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

此页面收集了一些关于以下内容的常见问题：

- [支持的文件格式](#Supported-File-Formats)。
- [对 Power BI Reporting 服务的支持](#Support-for-Power-BI-Reporting-services)。
- [安装](#Installation)。
- [导出配置](#Export-Configuration)。

{{% /alert %}} 
### **支持的文件格式**
#### **问：使用 Aspose.Slides for Reporting Services 可以导出到哪些格式的报告？**
**答**：Aspose.Slides for Reporting Services 可以将任何报告导出为 PPT、PPS、PPTX、PPSX、XPS 或 RPL 格式。
### **对 Power BI Reporting 服务的支持**
#### **问：Aspose.Slides for Reporting Services 支持 Power BI 吗？**
**答**：是的。Aspose.Slides for Reporting Services 支持在 Power BI 中导出分页报告 (RDL)。
### **安装**
#### **问：安装程序无法启动。手动安装没有达到预期结果。**
**答**：请确保您的系统上已安装 .NET Framework 3.5。
#### **问：安装 Aspose.Slides for Reporting Services 后，导出选项缺失。**
**答**：如果 rssrvpolicy.config 中的任何 CodeGroup 无法正常工作，配置文件解析器可能会跳过该组的最后几个部分。因此，请将与 Aspose.Slides for Reporting Services 相关的所有 CodeGroups 移动到包含 Aspose.Slides for Reporting Services CodeGroups 的块顶部。
#### **问：无法加载文件或程序集 Aspose.Slides.ReportingServices （无法获取执行权限 \ HRESULT：0x80131418 的异常）。**
**答**：错误代码 (0x80131418) 表示 dll 模块权限不足。这可能是由于一个安全特性阻止了对 .dll 文件的完全访问，如果该文件是从另一台计算机获取的。可以通过打开 dll 文件的属性窗口并在“安全”面板中点击“解锁”按钮来解决此问题。
#### **问：找不到许可证 'Aspose.Slides.Reporting.Services.lic'。**
**答**：许可证文件必须位于 dll 文件旁边或在 Program Files(x86)\Aspose\Slides\ 目录中。
### **导出配置**
#### **问：如何更改导出报告中超链接的颜色？**
**答**：在 rsreportserver.config 中，每个 Aspose.Slides for Reporting Services 渲染扩展都有自己的配置。要更改超链接颜色，请在 <HyperlinkColor> 部分设置所需值。
#### **问：在导出演示文稿中，表格中的文本垂直拉伸。**
**答**：这样做是为了使文档更易读。要使表格中的文本显示为报告中所示，请在 rsreportserver.config 配置文件中将所需的 Aspose.Slides for Reporting Services 扩展设置为“正常”。