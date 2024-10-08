---
title: 演示设置
type: docs
weight: 70
url: /jasperreports/demos-setup/
---

与 Aspose.Slides for JasperReports 提供的所有演示都是修改过的标准演示。最好将所有演示复制到 JasperReports 演示文件夹：
...\jasperreports-x.x.x\demo\samples\

使用标准命令序列构建和导出报告：

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

请不要忘记运行 HSQLDB 的测试数据库，以便为报告填充数据，并将 aspose.slides.jasperreports.library-xx.x.jar 从 aspose-slides-xx.x-jasperreports.zip 的 \lib\JasperReports X.X.X - X.X.X 文件夹复制到 &#60;InstallDir&#62;\lib 目录。

{{% /alert %}} 

大多数演示（除了图表）已经生成了演示文稿，因此您可以跳过所有“ant”步骤，直接检查结果。