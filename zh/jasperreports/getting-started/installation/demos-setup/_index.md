---
title: 演示设置
type: docs
weight: 70
url: /zh/jasperreports/demos-setup/
---
提供的 Aspose.Slides for JasperReports 示例全部是已更改的标准示例。最好将所有示例复制到 JasperReports 示例文件夹：
...\jasperreports-x.x.x\demo\samples\

使用标准命令顺序构建并导出报表：

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

请务必先运行带测试数据库的 HSQLDB，以填充报表数据，并将 aspose.slides.jasperreports.library-xx.x.jar 从 aspose-slides-xx.x-jasperreports.zip 的 \lib\JasperReports X.X.X - X.X.X 文件夹复制到 &#60;InstallDir&#62;\lib 目录。

{{% /alert %}} 

大多数示例（Charts 除外）已生成演示文稿，因此可以跳过所有 “ant” 步骤，直接检查结果。